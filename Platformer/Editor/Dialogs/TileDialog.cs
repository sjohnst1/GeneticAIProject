#region File Description
//-----------------------------------------------------------------------------
// TileDialog.cs
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
using System.IO;
using System.Windows.Forms;
using TilemapLibrary;
using TilemapPipelineExtension;

#endregion

namespace Editor
{
    /// <summary>
    /// A dialog exposing the properties of a single tile
    /// </summary>
    public partial class TileDialog : Form
    {
        #region Fields
        
        /// <summary>
        /// The MainForm that spawned this dialog - we need
        /// a reference to access the content pipline for laoding
        /// textures
        /// </summary>
        MainForm parent;
        
        /// <summary>
        /// The directory where we start looking for tile images
        /// </summary>
        string directory;
        
        /// <summary>
        /// The tile whose properties this dialog represents
        /// </summary>
        public Tile Tile;

        /// <summary>
        /// The filename of the image we loaded for the tile
        /// </summary>
        public string FileName;
        
        #endregion

        #region Initialization


        /// <summary>
        /// Creates a new TileDialog for creating a new Tile
        /// </summary>
        /// <param name="parent">The MainForm that created the dialog</param>
        /// <param name="imageDirectory">The directory to start looking for our tile images in</param>
        public TileDialog(MainForm parent, string imageDirectory)
        {
            InitializeComponent();
            this.parent = parent;
            this.directory = imageDirectory;

            // Populate our combo box with the tiletype enumeration
            foreach (TileType name in Enum.GetValues(typeof(TileType)))
            {
                comboBoxType.Items.Add(name);
            }
            comboBoxType.SelectedItem = TileType.Solid;
        }

        /// <summary>
        /// Creates a new TileDialog to represent an already-created Tile
        /// </summary>
        /// <param name="parent">The MainForm that created the dialog</param>
        /// <param name="imageDirectory">The directory to start looking for our tile images in</param>
        /// <param name="tileContent">The tileContent corresponding to the tile we are representing</param>
        public TileDialog(MainForm parent, string imageDirectory, TileContent tileContent) : this(parent, imageDirectory)
        {
            this.FileName = tileContent.Image.Filename;
            textBoxName.Text = tileContent.Name;
            pictureBox1.ImageLocation = this.FileName;
            Tile = new Tile();
            comboBoxType.SelectedItem = tileContent.TileType;
        }

        #endregion

        #region Event Handlers


        /// <summary>
        /// Event handler that loads a new texture for our tile 
        /// </summary>
        private void buttonLoadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();

            fileDialog.InitialDirectory = directory;
            fileDialog.Title = "Load Tile Image";
            fileDialog.Filter = "Image Files (*.png;*.bmp;*.jpg)|*.png;*.bmp;*.jpg;*.jpeg";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                // Store the filename
                FileName = fileDialog.FileName;

                // Load an image preview
                pictureBox1.ImageLocation = fileDialog.FileName;
                
                // Create the tile
                Tile = new Tile();
                Tile.Image = parent.LoadTexture(fileDialog.FileName);
                Tile.Name = textBoxName.Text;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            // Since we pass in the tile, or create a new one when an image is loaded,
            // we know we are missing an image if the Tile is null
            if (Tile == null)
            {
                MessageBox.Show("You must select an image for this tile", "Error");
                return;
            }

            if(string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("You must enter a name for this tile", "Error");
                return;
            }

            Tile.Name = textBoxName.Text;

            Tile.TileType = (TileType)comboBoxType.SelectedItem;

            DialogResult = DialogResult.OK;
        }

        #endregion

    }
}
