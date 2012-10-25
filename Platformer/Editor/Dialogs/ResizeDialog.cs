using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TilemapLibrary;

namespace Editor
{
    /// <summary>
    /// Anchor point for a TilemapLayer resize operation
    /// </summary>
    enum ResizeAnchor
    {
        TopLeft,
        TopCenter,
        TopRight,
        CenterRight,
        Center,
        CenterLeft,
        BottomRight,
        BottomCenter,
        BottomLeft,
    }

    public partial class ResizeDialog : Form
    {
        #region Field

        
        /// <summary>
        /// The TilemapLayer to resize
        /// </summary>
        public TilemapLayer Layer;


        /// <summary>
        /// The anchor location for resizing our tilemap
        /// </summary>
        ResizeAnchor resizeAnchor;


        #endregion

        #region Initialization


        /// <summary>
        /// Constructs a new ResizeDialog for resizing a TilemapLayer 
        /// </summary>
        public ResizeDialog(TilemapLayer layer)
        {
            InitializeComponent();
            Layer = layer;
            textBoxWidth.Text = layer.Width.ToString();
            textBoxHeight.Text = layer.Height.ToString();
            resizeAnchor = ResizeAnchor.TopRight;
        }


        #endregion

        #region Helper Methods


        /// <summary>
        /// Helper for resizing a TilemapLayer
        /// </summary>
        public void ResizeLayer(int newWidth, int newHeight)
        {
            // Create a new array
            int[] newTileData = new int[newWidth * newHeight];

            // Clear the array
            for (int i = 0; i < newWidth * newHeight; i++) newTileData[i] = -1;

            int offsetX = 0;
            int offsetY = 0;

            // Calculate the X offset
            switch (resizeAnchor)
            {
                case ResizeAnchor.TopLeft:
                case ResizeAnchor.CenterLeft:
                case ResizeAnchor.BottomLeft:
                    offsetX = 0;
                    break;
                case ResizeAnchor.TopCenter:
                case ResizeAnchor.Center:
                case ResizeAnchor.BottomCenter:
                    offsetX = (newWidth - Layer.Width) / 2;
                    break;
                case ResizeAnchor.TopRight:
                case ResizeAnchor.CenterRight:
                case ResizeAnchor.BottomRight:
                    offsetX = newWidth - Layer.Width;
                    break;
            }

            // Calculate the Y offset
            switch (resizeAnchor)
            {
                case ResizeAnchor.TopLeft:
                case ResizeAnchor.TopCenter:
                case ResizeAnchor.TopRight:
                    offsetY = 0;
                    break;
                case ResizeAnchor.CenterLeft:
                case ResizeAnchor.Center:
                case ResizeAnchor.CenterRight:
                    offsetY = (newHeight - Layer.Height) / 2;
                    break;
                case ResizeAnchor.BottomLeft:
                case ResizeAnchor.BottomCenter:
                case ResizeAnchor.BottomRight:
                    offsetY = newHeight - Layer.Height;
                    break;
            }

            // Copy old tiles to new array
            for (int x = Math.Max(0, -offsetX); x < Layer.Width && x < newWidth - offsetX; x++)
            {
                for (int y = Math.Max(0, -offsetY); y < Layer.Height && y < newHeight - offsetY; y++)
                {
                    newTileData[x + offsetX + (y + offsetY) * newWidth] = Layer.TileData[x + y * Layer.Width];
                }
            }

            // Assign new array as our TileData
            Layer.TileData = newTileData;
            Layer.Width = newWidth;
            Layer.Height = newHeight;
        }


        #endregion

        #region Event Handlers


        /// <summary>
        /// Event handler that applies the layer resize operation.
        /// </summary>
        private void buttonOK_Click(object sender, EventArgs e)
        {
            int width, height;

            try { width = int.Parse(textBoxWidth.Text); }
            catch { MessageBox.Show("You must enter a layer width", "Error"); return; }
            if (width <= 0) { MessageBox.Show("Layer width must be greater than 0"); return; }

            try { height = int.Parse(textBoxHeight.Text); }
            catch { MessageBox.Show("You must enter a layer height", "Error"); return; }
            if (height <= 0) { MessageBox.Show("Layer height must be greater than 0"); return; }

            ResizeLayer(width, height);

            DialogResult = DialogResult.OK;
        }


        /// <summary>
        /// Event handler for Top Left button; changes the resize anchor point
        /// </summary>
        private void radioButtonTL_CheckedChanged(object sender, EventArgs e)
        {
            resizeAnchor = ResizeAnchor.TopLeft;
        }


        /// <summary>
        /// Event handler for Top Center button; changes the resize anchor point
        /// </summary>
        private void radioButtonTC_CheckedChanged(object sender, EventArgs e)
        {
            resizeAnchor = ResizeAnchor.TopCenter;
        }


        /// <summary>
        /// Event handler for Top Right button; changes the resize anchor point
        /// </summary>
        private void radioButtonTR_CheckedChanged(object sender, EventArgs e)
        {
            resizeAnchor = ResizeAnchor.TopRight;
        }


        /// <summary>
        /// Event handler for Center Left button; changes the resize anchor point
        /// </summary>
        private void radioButtonCL_CheckedChanged(object sender, EventArgs e)
        {
            resizeAnchor = ResizeAnchor.CenterLeft;
        }

        
        /// <summary>
        /// Event handler for Center button; changes the resize anchor point
        /// </summary>
        private void radioButtonC_CheckedChanged(object sender, EventArgs e)
        {
            resizeAnchor = ResizeAnchor.Center;
        }


        /// <summary>
        /// Event handler for Center Right button; changes the resize anchor point
        /// </summary>
        private void radioButtonCR_CheckedChanged(object sender, EventArgs e)
        {
            resizeAnchor = ResizeAnchor.CenterRight;
        }


        /// <summary>
        /// Event handler for Bottom Left button; changes the resize anchor point
        /// </summary>
        private void radioButtonBL_CheckedChanged(object sender, EventArgs e)
        {
            resizeAnchor = ResizeAnchor.BottomLeft;
        }


        /// <summary>
        /// Event handler for Bottom Center button; changes the resize anchor point
        /// </summary>
        private void radioButtonBC_CheckedChanged(object sender, EventArgs e)
        {
            resizeAnchor = ResizeAnchor.BottomCenter;
        }


        /// <summary>
        /// Event handler for Bottom Right button; changes the resize anchor point
        /// </summary>
        private void radioButtonBR_CheckedChanged(object sender, EventArgs e)
        {
            resizeAnchor = ResizeAnchor.BottomRight;
        }


        #endregion
    }
}
