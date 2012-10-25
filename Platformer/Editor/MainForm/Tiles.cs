#region File Description
//-----------------------------------------------------------------------------
// Tiles.cs
//
// CIS 580 - Game Programming Fundamentals
// Computing and Information Science, Kansas State Univeristy
// Copyright (C) Nathan Bean.  Released under the Microsoft Permissive License
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
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Intermediate;
using TilemapPipelineExtension;
using TilemapLibrary;
#endregion

using XNAPoint = Microsoft.Xna.Framework.Point;

namespace Editor
{
    /// <summary>
    /// Custom form provides the main user interface for the program.
    /// Users are able to place tiles from the tile selection pane
    /// onto the map panel to define maps for tile engine-using games.
    /// </summary>
    public partial class MainForm : Form
    {
        #region Fields

        
        // The image list holds the images for the tile palette
        ImageList tileImageList;

        // And this list holds the loaded TileContent instances
        // for easy serialization
        List<TileContent> tilePalette;

		
        // Also store the name of the TilePalette
        string tilePaletteName;
        
        #endregion

        #region Initialization


        /// <summary>
        /// Initializes the tile-related functionality in
        /// the MainForm
        /// </summary>
        private void InitializeTiles()
        {
            // Set up the tileImageList
            tileImageList = new ImageList();
            tileImageList.ImageSize = new Size(50, 50);
            tileListView.LargeImageList = tileImageList;

            // Create the list of tile textures
            tilePalette = new List<TileContent>(16);

            // Assign our event handlers
            newTileToolStripMenuItem.Click += NewTileClicked;
            importTilePaletteToolStripMenuItem.Click += ImportTilePalette;
            exportTilePaletteToolStripMenuItem.Click += ExportTilePalette;
            
            tileListView.SelectedIndexChanged += SelectedTileChanged;
            tileListView.DoubleClick += EditTileClicked;
        }

        
        #endregion

        #region Event Handlers

		
        /// <summary>
        /// Event handler for new tile menu item click.  This brings
        /// up a tile properties dialog where the user can create a
        /// new tile
        /// </summary>
        void NewTileClicked(Object sender, EventArgs e)
        {
            TileDialog td = new TileDialog(this, tileImagePath);

            if (td.ShowDialog() == DialogResult.OK)
            {
                // Add the new tile to the tileListView, and assign it a new image
                tileListView.Items.Add(td.Tile.Name, tileImageList.Images.Count);

                // Add the new tile image to the image list
                tileImageList.Images.Add(Bitmap.FromFile(td.FileName));

                // Add the new tile to the tilemap's tile palette
                tilemap.TilePalette.Add(td.Tile);

                // Also add it to the mainform's tile palette
                tilePalette.Add(new TileContent(td.FileName) { Name = td.Tile.Name, TileType = td.Tile.TileType });

                // Auto-select the new tile
                mapViewerControl.SelectedTileIndex = tileListView.Items.Count - 1;
                tileListView.SelectedIndices.Clear();
                tileListView.SelectedIndices.Add(tileListView.Items.Count - 1);
            }
        }



        /// <summary>
        /// Event handler for when a new tile is selected from the tile palette.
        /// The MapViewerControl needs to be informed of the change, as it is 
        /// responsible for placing tiles.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        void SelectedTileChanged(Object obj, EventArgs e)
        {
            if(tileListView.SelectedIndices.Count > 0)
                mapViewerControl.SelectedTileIndex = tileListView.SelectedIndices[0];
        }
        
        

        /// <summary>
        /// Event handler for double-clicking a tile in the tile palette.
        /// This brings up a properties editor dialog for the tile.
        /// </summary>
        void EditTileClicked(object sender, EventArgs e)
        {
            int index = tileListView.SelectedIndices[0];

            TileContent tileContent = tilePalette[index];

            // Create a new TileDialog
            TileDialog td = new TileDialog(this, tileImagePath, tileContent);

            // Set the TileDialog's Tile to the selected tile
            td.Tile = mapViewerControl.Tilemap.TilePalette[index];

            if (td.ShowDialog() == DialogResult.OK)
            {
                // Swap the tile's name in the tileListView
                tileListView.Items[index].Text = td.Tile.Name;

                // Swap the tile's image in the tileImageList
                tileImageList.Images[index] = Bitmap.FromFile(td.FileName);

                // Swap the tile in the tilemap's tile palette
                tilemap.TilePalette[index] = td.Tile;

                // Swap the tile in the MainForm's tile palette
                tilePalette[index] = new TileContent(td.FileName) { Name = td.Tile.Name, TileType = td.Tile.TileType };
            }
        }


        /// <summary>
        /// Event handler for exporting the TilePalette to a tpal file.
        /// This allows us to quickly define tile palettes to share amongst
        /// similar maps.
        /// </summary>
        void ExportTilePalette(Object obj, EventArgs e)
        {
            // Create a SaveFileDialog to handle saving our file
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = tilePalettePath;
            sfd.DefaultExt = ".tpal";
            sfd.Filter = "tile palette files (*.tpal)|*.tpal";
            sfd.RestoreDirectory = true;
            sfd.FileName = tilePaletteName;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Cursor = Cursors.WaitCursor;

                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                using (XmlWriter writer = XmlWriter.Create(sfd.FileName, settings))
                {
                    // Serialize the tile palette to XML
                    IntermediateSerializer.Serialize(writer, tilePalette, null);
                }
                tilePaletteName = sfd.FileName;

                Cursor = Cursors.Arrow;
            }
        }


        /// <summary>
        /// Event handler for importing a tile palette.  This method
        /// appends the tiles from the imported tile palette to the 
        /// existing tile palette - effectively combining the two sets.
        /// </summary>
        void ImportTilePalette(Object obj, EventArgs e)
        {
            // Create a OpenFileDialog to find our file
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = tilePalettePath;
            ofd.DefaultExt = ".tpal";
            ofd.Filter = "tile palette files (*.tpal)|*.tpal";
            ofd.RestoreDirectory = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Cursor = Cursors.WaitCursor;

                using (XmlReader reader = XmlReader.Create(ofd.FileName))
                {
                    List<TileContent> importTilePalette = IntermediateSerializer.Deserialize<List<TileContent>>(reader, null);

                    foreach (TileContent tileContent in importTilePalette)
                    {
                        // Create the equivalent Tile and append it to our tilemap's palette
                        Tile tile = new Tile();
                        tile.Name = tileContent.Name;
                        tile.Image = LoadTexture(tileContent.Image.Filename);
                        tilemap.TilePalette.Add(tile);

                        // Append the tileContent to our tile palette
                        tilePalette.Add(tileContent);

                        // Append the new tile to the tileListView
                        tileListView.Items.Add(tileContent.Name, tileImageList.Images.Count);

                        // Append the new tile image to our tileImageList
                        tileImageList.Images.Add(Bitmap.FromFile(tileContent.Image.Filename));
                    }
                }

                Cursor = Cursors.Arrow;
            }
        }

        
        #endregion

        #region Helper Methods


        /// <summary>
        /// Loads a Texture2D using the XNA pipeline functionality
        /// </summary>
        /// <param name="fileName">The filename of the image to load</param>
        /// <returns></returns>
        public Texture2D LoadTexture(string fileName)
        {
            Texture2D texture = null;

            // Tell our ContentBuilder to build our texture
            contentBuilder.Clear();
            contentBuilder.Add(fileName, Path.GetFileNameWithoutExtension(fileName), null, "TextureProcessor");

            // Build the XNA texture 
            string buildError = contentBuilder.Build();

            if (string.IsNullOrEmpty(buildError))
            {
                // If build succeeded, use content manager to load texture
                texture = contentManager.Load<Texture2D>(Path.GetFileNameWithoutExtension(fileName));
            }
            else
            {
                // If the build failed, display error message.
                MessageBox.Show(buildError, "Error");
            }

            return texture;
        }

        #endregion
    }
}
