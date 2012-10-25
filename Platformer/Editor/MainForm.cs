#region File Description
//-----------------------------------------------------------------------------
// MainForm.cs
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
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using TilemapLibrary;
#endregion

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

        ContentBuilder contentBuilder;
        ContentManager contentManager;

        // The directory paths for our editor files
        string tileImagePath;
        string tilemapPath;
        string tilePalettePath;
        string editorContentPath;

        #endregion

        #region Initialization

        /// <summary>
        /// Constructs the main form.
        /// </summary>
        public MainForm()
        {
            // Configure our paths
            string basePath = Path.Combine(Assembly.GetCallingAssembly().Location, "../../../../../");
            tileImagePath = Path.GetFullPath(Path.Combine(basePath, "TileImages"));
            Directory.CreateDirectory(tileImagePath);
            tilemapPath = Path.GetFullPath(Path.Combine(basePath, "Tilemaps"));
            Directory.CreateDirectory(tilemapPath);
            tilePalettePath = Path.GetFullPath(Path.Combine(basePath, "TilePalettes"));
            Directory.CreateDirectory(tilePalettePath);
            editorContentPath = Path.GetFullPath(Path.Combine(basePath, "Editor/Content"));

            // Initialize our Components
            InitializeComponent();
            InitializeMap();
            InitializeTiles();
            InitializeTools();
            InitializeLayers();
            InitializeObjects();

            // Create our XNA objects
            contentBuilder = new ContentBuilder();

            contentManager = new ContentManager(mapViewerControl.Services,
                                                contentBuilder.OutputDirectory);

        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Event handler for the Exit menu option.
        /// </summary>
        void ExitMenuClicked(object sender, EventArgs e)
        {
            Close();
        }

        #endregion
        
    }
}
