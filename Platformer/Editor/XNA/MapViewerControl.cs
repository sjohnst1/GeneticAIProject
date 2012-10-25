#region File Description
//-----------------------------------------------------------------------------
// MapViewerControl.cs
//
// Platformer Project, CIS 580 Course
// Department of Computing and Informaiton Sciences
// Kansas State University
// Copyright (c) 2011 Nathan H. Bean
// Released under the Microsoft Permissive License
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using System;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using TilemapLibrary;
#endregion

namespace Editor
{
    public enum EditorToolState
    {
        Paint,
        Fill,
    }

    /// <summary>
    /// Example control inherits from GraphicsDeviceControl, and displays
    /// a spinning 3D model. The main form class is responsible for loading
    /// the model: this control just displays it.
    /// </summary>
    class MapViewerControl : GraphicsDeviceControl
    {
        #region Fields

        SpriteBatch spriteBatch;
        BasicEffect basicEffect;
        Viewport viewport;
        EditorToolState toolState;

        // Object textures
        public Texture2D PlayerStartTexture;
        public Texture2D WhiteGemTexture;
        public Texture2D RedGemTexture;
        public Texture2D GoldGemTexture;
        public Texture2D EnemyATexture;
        public Texture2D EnemyBTexture;
        public Texture2D EnemyCTexture;
        public Texture2D EnemyDTexture;

        #endregion

        #region Members

        /// <summary>
        /// The currently selected tile index (from the tile palette), or -1 if no tile is selected
        /// </summary>
        public int SelectedTileIndex
        {
            get { return selectedTile; }
            set { selectedTile = value; }
        }
        protected int selectedTile = -1;


        /// <summary>
        /// The currently selected object index, or null if no object is selected
        /// </summary>
        public int SelectedObjectIndex
        {
            get { return selectedObject; }
            set { selectedObject = value; }
        }
        protected int selectedObject = 0;


        /// <summary>
        /// The currently selected layer index
        /// </summary>
        public int SelectedLayerIndex
        {
            get { return selectedLayer; }
            set { selectedLayer = value; }
        }
        protected int selectedLayer = 0;

        /// <summary>
        /// The current tool state
        /// </summary>
        public EditorToolState ToolState
        {
            get { return toolState; }
            set { toolState = value; }
        }

        ///// <summary>
        ///// The currently displayed and edited Tilemap
        ///// </summary>
        public  Tilemap Tilemap;


        /// <summary>
        /// The current camera position (offset to the viewport corner)
        /// </summary>
        public Point Camera
        {
            set
            {
                camera.X = value.X * Tilemap.TileWidth;
                camera.Y = value.Y * Tilemap.TileHeight;
            }
        }
        Vector3 camera;

        #endregion

        #region Initialization

        /// <summary>
        /// Initializes the control.
        /// </summary>
        protected override void Initialize()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
  
            viewport = GraphicsDevice.Viewport;

            camera = Vector3.Zero;

            // The BasicEffect is used to override the default SpriteBatch effect
            // We need to turn on the use of textures and colored vertices to
            // duplicate our normal SpriteBatch behaviors.  We'll also want to set
            // up Identity transforms (no-op) for the world and view, and initialize
            // our projection matrix to the control's client area.
            basicEffect = new BasicEffect(GraphicsDevice)
            {
                TextureEnabled = true,
                VertexColorEnabled = true,
            };
            basicEffect.World = Matrix.Identity;
            basicEffect.View = Matrix.Identity;
            basicEffect.Projection = Matrix.CreateOrthographicOffCenter(0, viewport.Width, viewport.Height, 0, 0, 1);

            toolState = EditorToolState.Paint;

            this.Resize += MapViewerResized;
            this.MouseMove += MapViewerMouseEvent;
            this.MouseDown += MapViewerMouseEvent;
            
            // Hook the idle event to constantly redraw our animation.
            Application.Idle += delegate { Invalidate(); };
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Event handler for rezising of the MapViewer Control.  We adjust the 
        /// viewport size and recompute the projection matrix to avoid stretching
        /// or squishing the rendered map.
        /// </summary>
        void MapViewerResized(object sender, EventArgs e)
        {
            viewport = new Viewport(0, 0, Width, Height);
            GraphicsDevice.Viewport = viewport;
            basicEffect.Projection = Matrix.CreateOrthographicOffCenter(0, viewport.Width, viewport.Height, 0, 0, 1);
        }
        

        /// <summary>
        /// Event handler for clicks on the MapViewerControl.  Currently we
        /// are just placing the selected tile in any spot the mouse is held
        /// down for - basic paintbrush operation.
        /// </summary>
        void MapViewerMouseEvent(object sender, MouseEventArgs me)
        {
            if (Tilemap != null)
            {
                Point mapCoords;
                mapCoords.X = (me.X + (int)camera.X) / Tilemap.TileWidth;
                mapCoords.Y = (me.Y + (int)camera.Y) / Tilemap.TileHeight;


                switch (toolState)
                {
                    case EditorToolState.Paint:

                        if (me.Button == MouseButtons.Left)
                            // Set the selected tile
                            SetTile(mapCoords, SelectedLayerIndex, SelectedTileIndex);
                        else if (me.Button == MouseButtons.Right)
                            // Erase the clicked tile
                            SetTile(mapCoords, SelectedLayerIndex, -1);
                        break;

                    case EditorToolState.Fill:
                        if( me.Button == MouseButtons.Left)
                            // Flood fill starting in the selected tile
                            Fill(mapCoords, SelectedLayerIndex, SelectedTileIndex);
                        else if( me.Button == MouseButtons.Right)
                            // Flood fill empty tiles starting in the selected tile
                            Fill(mapCoords, SelectedLayerIndex, -1); 
                        break;
                }
            }
        }

        #endregion

        #region Drawing

        /// <summary>
        /// Draws the control.
        /// </summary>
        protected override void Draw()
        {
            // We create a translation matrix and use it for our world transform;
            // this allows us to scroll through the world.  Because this operation
            // is applied on the GPU, it is a more efficient approach than a CPU-
            // bound operation.
            basicEffect.World = Matrix.CreateTranslation(-camera);

            // Clear to the default control background color.
            Color backColor = new Color(BackColor.R, BackColor.G, BackColor.B);
            GraphicsDevice.Clear(backColor);

             // If we have a tilemap, we'll go ahead and render our tilemap
             // using the basicEffect, which will apply our world and view 
             // transforms.  Eventually we may want to limit the parts of the 
             // map we are actually drawing to those that will fall into our
             // viewport.
            if (Tilemap != null)
            {
                spriteBatch.Begin(0, null, null, null, null, basicEffect);
                
                // Draw the tilemap
                Tilemap.Draw(spriteBatch);

                spriteBatch.End();
            }
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Places a tile in the map
        /// </summary>
        /// <param name="coords">The coordinates to place the tile at</param>
        /// <param name="layerIndex">The index of the laye to place the tile at</param>
        /// <param name="tileIndex">The index of the tile, in the tile palette</param>
        private void SetTile(Point coords, int layerIndex, int tileIndex)
        {
            if (layerIndex < Tilemap.Layers.Count && Tilemap.Layers[layerIndex] != null && tileIndex >= -1 && tileIndex < Tilemap.TilePalette.Count)
            {
                TilemapLayer layer = Tilemap.Layers[layerIndex];

                if (coords.X >= 0 && coords.X < layer.Width && coords.Y >= 0 && coords.Y < layer.Height)
                {
                    layer.TileData[coords.X + coords.Y * layer.Width] = tileIndex;
                }
            }
        }

        /// <summary>
        /// Fills the selected, contiguous region with a tile
        /// </summary>
        /// <param name="coords">The coordinates of a tile within the region to fill</param>
        /// <param name="layerIndex">The index of the layer with the region to fill</param>
        /// <param name="tileIndex">The indes of the fill tile in tile palette</param>
        private void Fill(Point coords, int layerIndex, int tileIndex)
        {
            if (layerIndex < Tilemap.Layers.Count && Tilemap.Layers[layerIndex] != null && tileIndex >= -1 && tileIndex < Tilemap.TilePalette.Count)
            {
                TilemapLayer layer = Tilemap.Layers[layerIndex];

                if (coords.X >= 0 && coords.X < layer.Width && coords.Y >= 0 && coords.Y < layer.Height)
                {
                    int oldIndex = layer.TileData[coords.X + coords.Y * layer.Width];
                    // Disallow filling a tile with the same tile
                    if(tileIndex != oldIndex)
                        Flood(layer, coords.X, coords.Y, oldIndex, tileIndex);
                }
            }
        }

        /// <summary>
        /// Recursive method for filling a space with a particular tile.
        /// </summary>
        /// <param name="x">The X position of the tile to fill</param>
        /// <param name="y">The y position of the tile to fill</param>
        /// <param name="oldIndex">The index we are replacing</param>
        /// <param name="newIndex">The index we are replacing with</param>
        protected void Flood(TilemapLayer layer, int x, int y, int oldIndex, int newIndex)
        {
            if (x >= 0 && x < layer.Width && y >= 0 && y < layer.Height && layer.TileData[x + y * layer.Width] == oldIndex)
            {
                layer.TileData[x + y * layer.Width] = newIndex;
                Flood(layer, x + 1, y, oldIndex, newIndex);
                Flood(layer, x - 1, y, oldIndex, newIndex);
                Flood(layer, x, y + 1, oldIndex, newIndex);
                Flood(layer, x, y - 1, oldIndex, newIndex);
            }
        }


        #endregion
    }
}
