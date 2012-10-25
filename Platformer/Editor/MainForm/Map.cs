#region File Description
//-----------------------------------------------------------------------------
// Map.cs
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
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;
using System.Xml;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Intermediate;
using TilemapLibrary;
using TilemapPipelineExtension;
#endregion

using XNAPoint = Microsoft.Xna.Framework.Point;

namespace Editor
{
    /// <summary>
    /// Partial class defining the Map-related functionality for
    /// the editor application's MainForm.  Map loading, saving,
    /// and creation are handled by this class, as well as changing
    /// the visual aspects of the map, like Scrolling and Zooming.
    /// </summary>
    public partial class MainForm : Form
    {
        #region Fields

        /// <summary>
        /// A reference to the tilemap held by the MapViewerControl
        /// </summary>
        Tilemap tilemap
        {
            get { return mapViewerControl.Tilemap; }
            set { mapViewerControl.Tilemap = value; }
        }

        /// <summary>
        /// Indicates if there have been changes to the tilemap since the last save
        /// </summary>
        bool mapDirty = false;

        
        #endregion

        #region Initialization

        /// <summary>
        /// Initializes the map-related functionality in
        /// the MainForm
        /// </summary>
        private void InitializeMap()
        {
            // Create a blank tilemap
            tilemap = new Tilemap("Untitled", 1, 100, 100, 50, 50);
            
            // Assign our event handlers
            newMapImageToolstripMenuItem.Click += NewMapClicked;
            loadTilemapToolStripMenuItem.Click += LoadMapClicked;
            saveTilemapToolStripMenuItem.Click += SaveMapClicked;

            hScrollBarMap.Scroll += MapScrolled;
            vScrollBarMap.Scroll += MapScrolled;
        }

        #endregion

        #region Event Handlers


        /// <summary>
        /// Event handler for scroll events with the map's scrollbars.
        /// We use the scrollbar values as the X and Y position of the 
        /// camera; this corresponds to the upper-left-most displayed tile
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MapScrolled(object sender, EventArgs e)
        {
            if (tilemap != null)
            {
                mapViewerControl.Camera = new XNAPoint(hScrollBarMap.Value, vScrollBarMap.Value);
            }
        }


        /// <summary>
        /// Event handler for the "New Map" menu item.  Launches
        /// a dialog to colleced the needed map information. If 
        /// the dialog is successful, the resulting map is loaded
        /// into the editor.
        /// </summary>
        void NewMapClicked(object sender, EventArgs e)
        {
            if (mapDirty)
            {
                if(DialogResult.Yes != MessageBox.Show("The map has not been saved.  Continue creating a new map?", "Warning", MessageBoxButtons.YesNo))
                return;
            }

            MapDialog mapDialog = new MapDialog();

            if (mapDialog.ShowDialog(this) == DialogResult.OK)
            {
                // Store the resulting tilemap
                tilemap = mapDialog.Tilemap;

                // Set the scrollbar maximums to match our map size
                hScrollBarMap.Maximum = tilemap.Width;
                vScrollBarMap.Maximum = tilemap.Height;

                // Clear our old lists
                tileImageList.Images.Clear();
                tileListView.Items.Clear();
                tilePalette.Clear();
                listBoxLayers.Items.Clear();

                // Add our layers to the layer list gui
                foreach(TilemapLayer layer in tilemap.Layers)
                {
                    listBoxLayers.Items.Add(layer.Name);
                }

                // Mark the map as dirty until it is saved
                mapDirty = true;
            }
        }


        /// <summary>
        /// Event handler for when the "Save Map" menu item is clicked
        /// </summary>
        void SaveMapClicked(object sender, EventArgs e)
        {
            // Create a SaveFileDialog to handle saving our file
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = tilemapPath;
            sfd.DefaultExt = ".tmap";
            sfd.Filter = "tilemap files (*.tmap)|*.tmap";
            sfd.RestoreDirectory = true;
            sfd.FileName = tilemap.Name;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Cursor = Cursors.WaitCursor;

                // Create a TilemapContent equivalent to our Tilemap for
                // easier serialization
                TilemapContent tilemapContent = new TilemapContent();
                tilemapContent.Name = tilemap.Name;
                tilemapContent.Width = tilemap.Width;
                tilemapContent.Height = tilemap.Height;
                tilemapContent.TileWidth = tilemap.TileWidth;
                tilemapContent.TileHeight = tilemap.TileHeight;
                
                // Since we already have a palette of TileContent, we'll use that
                tilemapContent.TilePalette = tilePalette;

                // Copy across our layers
                tilemapContent.Layers = new List<TilemapLayerContent>(tilemap.Layers.Count);
                foreach(TilemapLayer layer in tilemap.Layers)
                {   
                    // Create a layer content to represent the layer
                    TilemapLayerContent layerContent = new TilemapLayerContent()
                    {
                        Name = layer.Name,
                        Width = layer.Width,
                        Height = layer.Height,
                        TileWidth = layer.TileWidth,
                        TileHeight = layer.TileHeight,
                        TileData = layer.TileData
                    };

                    // Add the layer to the TilemapContent so it is serialzied
                    tilemapContent.Layers.Add(layerContent);
                }
                
                // Serialize and write to disc
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                using (XmlWriter writer = XmlWriter.Create(sfd.FileName, settings))
                {
                    IntermediateSerializer.Serialize(writer, tilemapContent, null);
                }
                tilemap.Name = Path.GetFileNameWithoutExtension(sfd.FileName);

                // Mark our map as clean
                mapDirty = false;

                Cursor = Cursors.Arrow;
            }
        }


        /// <summary>
        /// Event handler for when the "Load Map" menu item is clicked
        /// </summary>
        void LoadMapClicked(Object obj, EventArgs e)
        {
            // Make sure the current map is saved, or intentionally being discarded
            if (mapDirty)
            {
                string message = "The current tilemap has not been saved - opening a new one will lose any changes you made.  Are you sure you want to continue?";
                if (DialogResult.Yes != MessageBox.Show(message, "Warning", MessageBoxButtons.YesNo))
                    return;
            }

            // Create a OpenFileDialog to find our file
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = tilemapPath;
            ofd.DefaultExt = ".tmap";
            ofd.Filter = "tilemap files (*.tmap)|*.tmap";
            ofd.RestoreDirectory = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Cursor = Cursors.WaitCursor;

                using (XmlReader reader = XmlReader.Create(ofd.FileName))
                {
                    TilemapContent tilemapContent = IntermediateSerializer.Deserialize<TilemapContent>(reader, null);

                    // Create a tilemap with the same size as our loaded one
                    tilemap = new Tilemap(tilemapContent.Name, tilemapContent.Layers.Count, tilemapContent.Width, tilemapContent.Height, tilemapContent.TileHeight, tilemapContent.TileWidth);
                    
                    // Clear our old lists
                    tileImageList.Images.Clear();
                    tileListView.Items.Clear();
                    tilePalette.Clear();

                    // Create the tiles
                    foreach (TileContent tileContent in tilemapContent.TilePalette)
                    {
                        // Load the texture through the content pipline so we can render it
                        // in our XNA controls
                        Texture2D texture = LoadTexture(tileContent.Image.Filename);

                        // Create an instance of the tile and add it to the palette
                        Tile tile = new Tile(){ 
                            Name = tileContent.Name,
                            Image = texture 
                        };
                        tilemap.TilePalette.Add(tile);

                        // Add the new tile image to the tileListView, and assign it a new image
                        tileListView.Items.Add(tileContent.Name, tileImageList.Images.Count);

                        // Load the new image representing our new tile
                        tileImageList.Images.Add(Bitmap.FromFile(tileContent.Image.Filename));

                        // Add the TileContent to our TilePalette
                        tilePalette.Add(tileContent);
                    }

                    // Create the layers
                    tilemap.Layers.Clear();
                    listBoxLayers.Items.Clear();
                    foreach (TilemapLayerContent layerContent in tilemapContent.Layers)
                    {
                        // Create a corresponding TilemapLayer
                        TilemapLayer layer = new TilemapLayer(layerContent.Name, layerContent.Width, layerContent.Height, layerContent.TileWidth, layerContent.TileHeight);
                        layer.TileData = layerContent.TileData;

                        // Add the layer to our tilemap
                        tilemap.Layers.Add(layer);

                        // Add the layer to our layer GUI list
                        listBoxLayers.Items.Add(layer.Name);
                    }
                   
                    // Deselect the selected tile index on the mapViewer 
                    mapViewerControl.SelectedTileIndex = -1;
                }

                Cursor = Cursors.Arrow;
            }
        }

        #endregion
    }
}
