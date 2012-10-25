#region File Description
//-----------------------------------------------------------------------------
// MapDialog.cs
//
// CIS 580 - Game Programming Fundamentals
// Computing and Information Science, Kansas State Univeristy
// Copyright (C) Nathan Bean.  Released under the Microsoft Permissive License
//-----------------------------------------------------------------------------
#endregion

#region Using Statements

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TilemapLibrary;

#endregion

namespace Editor
{
    /// <summary>
    /// Dialog exposes the properties of a Tilemap, used to create
    /// new tilemaps
    /// </summary>
    public partial class MapDialog : Form
    {
        #region Fields


        /// <summary>
        /// The tilemap created by the dialog
        /// </summary>
        public Tilemap Tilemap;


        #endregion

        #region Initialization


        /// <summary>
        /// Constructs a new MapDialog instance
        /// </summary>
        public MapDialog()
        {
            InitializeComponent();
        }


        #endregion

        #region Event Handlers

        /// <summary>
        /// Clicking the OK button validates the values provided by
        /// the form, and if successful, creates a new tilemap using
        /// those values, setting the DialogResult to true
        /// </summary>
        private void buttonOK_Click(object sender, EventArgs e)
        {
            string mapName;
            int mapLayers, mapWidth, mapHeight, tileWidth, tileHeight;

            mapName = textBoxMapName.Text;
            if(string.IsNullOrEmpty(mapName)) { MessageBox.Show("You must enter a map name", "Error"); return;}

            try { mapLayers = int.Parse(textBoxLayers.Text); }
            catch { MessageBox.Show("You must enter a map width", "Error"); return; }
            if (mapLayers <= 0) { MessageBox.Show("Map width must be greater than 0"); return; }

            try { mapWidth = int.Parse(textBoxMapWidth.Text); } 
            catch { MessageBox.Show("You must enter a map width", "Error"); return;}
            if (mapWidth <= 0) { MessageBox.Show("Map width must be greater than 0"); return; }

            try { mapHeight = int.Parse(textBoxMapHeight.Text); } 
            catch { MessageBox.Show("You must enter a map height", "Error"); return;}
            if (mapHeight <= 0) { MessageBox.Show("Map height must be greater than 0"); return; }

            try { tileWidth = int.Parse(textBoxTileWidth.Text); }
            catch { MessageBox.Show("You must enter a tile width", "Error"); return; }
            if (tileWidth <= 0) { MessageBox.Show("Tile width must be greater than 0"); return; }

            try { tileHeight = int.Parse(textBoxTileHeight.Text); }
            catch { MessageBox.Show("You must enter a tile height", "Error"); return; }
            if (tileHeight <= 0) { MessageBox.Show("Tile height must be greater than 0"); return; }

            Tilemap = new Tilemap(mapName, mapLayers, mapWidth, mapHeight, tileWidth, tileHeight);

            DialogResult = DialogResult.OK;
        }

        #endregion
    }
}
