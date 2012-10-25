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

        
        
        #endregion

        #region Initialization


        /// <summary>
        /// Initializes the tile-related functionality in
        /// the MainForm
        /// </summary>
        private void InitializeTools()
        {
            toolStripButtonPaint.CheckState = CheckState.Checked;

            toolStripButtonPaint.Click += PaintToolClick;
            toolStripButtonFill.Click += FillToolClick;
            toolStripButtonPin.Click += PinToolClick;
        }

        
        #endregion

        #region Event Handlers


        /// <summary>
        /// Event handler for when the paint tool is clicked
        /// </summary>
        void PaintToolClick(Object sender, EventArgs e)
        {
            mapViewerControl.ToolState = EditorToolState.Paint;
            toolStripButtonPaint.CheckState = CheckState.Checked;
            toolStripButtonFill.CheckState = CheckState.Unchecked;
        }


        /// <summary>
        /// Event handler for when the fill tool is clicked.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        void FillToolClick(Object obj, EventArgs e)
        {
            mapViewerControl.ToolState = EditorToolState.Fill;
            toolStripButtonFill.CheckState = CheckState.Checked;
            toolStripButtonPaint.CheckState = CheckState.Unchecked;
        }


        /// <summary>
        /// Event handler for when teh pin tool is clicked
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        void PinToolClick(Object obj, EventArgs e)
        {
            toolStripButtonPaint.CheckState = CheckState.Unchecked;
            toolStripButtonFill.CheckState = CheckState.Unchecked;
        }


        #endregion

        #region Helper Methods


        
        #endregion
    }
}
