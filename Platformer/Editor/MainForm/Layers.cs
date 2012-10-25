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
        /// Initializes the layer-related functionality in
        /// the MainForm
        /// </summary>
        private void InitializeLayers()
        {
            foreach (TilemapLayer layer in tilemap.Layers)
            {
                listBoxLayers.Items.Add(layer.Name);
            }

            resizeLayerToolStripMenuItem.Click += ResizeLayerClick;
            newLayerToolStripMenuItem.Click += NewLayerClick;
            
            listBoxLayers.MouseDown += LayerMouseDown;
            listBoxLayers.DragDrop += LayerDragDrop;
            listBoxLayers.DragOver += LayerDragOver;
            listBoxLayers.DoubleClick += LayerDoubleClick;
            listBoxLayers.SelectedIndexChanged += LayerIndexChanged;
        }

        
        #endregion

        #region Event Handlers

        
        /// <summary>
        /// Event handler to create a new layer in the tilemap.  The new
        /// layer is appended to the end of the list.
        /// </summary>
        void NewLayerClick(object sender, EventArgs e)
        {
            string name = "Layer " + tilemap.Layers.Count.ToString();
            tilemap.Layers.Add(new TilemapLayer(name, tilemap.Width, tilemap.Height, tilemap.TileWidth, tilemap.TileHeight));
            listBoxLayers.Items.Add(name);
        }


        /// <summary>
        /// Event handler to resize a layer - launches a resize dialog
        /// </summary>
        void ResizeLayerClick(object sender, EventArgs e)
        {
            if (listBoxLayers.SelectedIndex != -1)
            {
                new ResizeDialog(tilemap.Layers[listBoxLayers.SelectedIndex]).ShowDialog();
            }
            else
            {
                MessageBox.Show("You must select a layer to resize!", "Error");
            }
        }


        /// <summary>
        /// Event handler for when the layer index is changed - informs the MapViewControl 
        /// of the newly selected layer
        /// </summary>
        void LayerIndexChanged(object sender, EventArgs e)
        {   
            mapViewerControl.SelectedLayerIndex = listBoxLayers.SelectedIndex;   
        }


        /// <summary>
        /// Event handler for a mousedown event on the layer list.
        /// If there was a left-click on a tilemap item, we want to 
        /// trigger a dragdrop operation.
        /// </summary>
        void LayerMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                int index = listBoxLayers.IndexFromPoint(e.Location);
                if (index != -1)
                {
                    listBoxLayers.DoDragDrop(index.ToString(), DragDropEffects.Move);
                }
                listBoxLayers.SelectedIndex = index;
                mapViewerControl.SelectedLayerIndex = listBoxLayers.SelectedIndex;
            }
        }


        /// <summary>
        /// Event handler for a dragdrop operation on the layer list gui
        /// element.  If the drop is in a valid position, we want to 
        /// re-order the layers.
        /// </summary>
        void LayerDragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                // Get the old and new index
                int dragIndex = Convert.ToInt32(e.Data.GetData(DataFormats.Text));
                int index = listBoxLayers.IndexFromPoint(listBoxLayers.PointToClient(new Point(e.X, e.Y)));

                if (index != -1)
                {
                    // Reorder the listbox
                    object obj = listBoxLayers.Items[dragIndex];
                    listBoxLayers.Items.Remove(obj);
                    listBoxLayers.Items.Insert(index, obj);

                    // Reorder the corresponding tilemap layers
                    TilemapLayer layer = tilemap.Layers[dragIndex];
                    tilemap.Layers.Remove(layer);
                    tilemap.Layers.Insert(index, layer);
                }
            }
        }


        /// <summary>
        /// DragOver event handler for the layer list gui.  We want
        /// to allow a move effect.
        /// </summary>
        void LayerDragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Move;
            }
        }


        /// <summary>
        /// Event handler for a double-click on the layer list.  Opens
        /// a dialog for editing the layer properties.
        /// </summary>
        void LayerDoubleClick(object sender, EventArgs e)
        {   
            int index = listBoxLayers.SelectedIndex;

            if (index >= 0 && index < tilemap.Layers.Count)
            {
                TilemapLayer layer = tilemap.Layers[index];
                if (new LayerDialog(layer).ShowDialog() == DialogResult.OK)
                {
                    listBoxLayers.Items[index] = layer.Name;
                }
            }
        }


        #endregion

        #region Helper Methods
        
        #endregion
    }
}
