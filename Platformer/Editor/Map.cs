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
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using TilemapLibrary;
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

        Tilemap tilemap;
        bool mapDirty = false;
        ScrollBar hScrollBarMap;
        ScrollBar vScrollBarMap;

        #endregion

        #region Initialization

        /// <summary>
        /// Initializes the map-related functionality in
        /// the MainForm
        /// </summary>
        private void InitializeMap()
        {
            newMapToolStripMenuItem.Click += NewMapMenuClicked;
            hScrollBar2.Scroll += MapScrolled;
            vScrollBar1.Scroll += MapScrolled;
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Event handler for the "New Map" menu item.  Launches
        /// a dialog to colleced the needed map information. If 
        /// the dialog is successful, the resulting map is loaded
        /// into the editor.
        /// </summary>
        void NewMapMenuClicked(object sender, EventArgs e)
        {
            if (mapDirty)
            {
                if (DialogResult.Yes != MessageBox.Show("The map has not been saved.  Continue creating a new map?", "Warning", MessageBoxButtons.YesNo))
                    return;
            }

            MapDialog mapDialog = new MapDialog();

            if (mapDialog.ShowDialog(this) == DialogResult.OK)
            {
                // Store the resulting tilemap
                tilemap = mapDialog.Tilemap;
                mapViewerControl.Tilemap = tilemap;

                // Set the scrollbar maximums to match our map size
                hScrollBar2.Maximum = tilemap.Width;
                vScrollBar1.Maximum = tilemap.Height;
				
				// Clear our old lists
				tileImageList.Images.Clear();
				tileListView.Items.Clear();
				tilePalette.Clear();

                // Mark the map as dirty until it is saved
                mapDirty = true;
            }
        }


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
                mapViewerControl.Camera = new XNAPoint(hScrollBar2.Value, vScrollBar1.Value);
            }
        }

        #endregion
    }
}
