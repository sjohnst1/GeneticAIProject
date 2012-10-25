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
        ImageList objectImageList;
        
        #endregion

        #region Initialization


        /// <summary>
        /// Initializes the tile-related functionality in
        /// the MainForm
        /// </summary>
        private void InitializeObjects()
        {
            // Set up the tileImageList
            objectImageList = new ImageList();
            objectImageList.ImageSize = new Size(50, 50);
            objectListView.LargeImageList = objectImageList;
            
            objectListView.SelectedIndexChanged += SelectedObjectChanged;
        }

        
        #endregion

        #region Event Handlers

        void SelectedObjectChanged(Object obj, EventArgs e)
        {
            if (objectListView.SelectedIndices.Count > 0)
                mapViewerControl.SelectedObjectIndex = objectListView.SelectedIndices[0];
        }
		        
        #endregion

        #region Helper Methods


        #endregion
    }
}
