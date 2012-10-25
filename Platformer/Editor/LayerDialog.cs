#region File Description
//-----------------------------------------------------------------------------
// LayerDialog.cs
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

using XNAColor = Microsoft.Xna.Framework.Color;

namespace Editor
{
    public partial class LayerDialog : Form
    {
        #region Fields


        /// <summary>
        /// The layer whose properties the dialog exposes
        /// </summary>
        public TilemapLayer Layer;


        #endregion

        #region Initialization


        /// <summary>
        /// Creates a new dialog exposing the properties of a TilemapLayer
        /// </summary>
        /// <param name="layer">The TilemapLayer to edit</param>
        public LayerDialog(TilemapLayer layer)
        {
            Layer = layer;

            InitializeComponent();

            textBoxName.Text = layer.Name;

            textBoxRed.Text = layer.Color.R.ToString();
            trackBarRed.Value = layer.Color.R;
            textBoxGreen.Text = layer.Color.G.ToString();
            trackBarGreen.Value = layer.Color.G;
            textBoxBlue.Text = layer.Color.B.ToString();
            trackBarBlue.Value = layer.Color.B;
            textBoxOpacity.Text = layer.Color.A.ToString();
            trackBarOpacity.Value = layer.Color.A;

            checkBoxVisible.Checked = layer.Visible;
        }


        #endregion

        #region Event Handlers


        /// <summary>
        /// Event handler to apply the changes entered into the dialog
        /// to the TilemapLayer
        /// </summary>
        private void buttonOK_Click(object sender, EventArgs e)
        {
            Layer.Name = textBoxName.Text;

            Layer.Visible = checkBoxVisible.Checked;

            int red = trackBarRed.Value;
            int green = trackBarGreen.Value;
            int blue = trackBarBlue.Value;
            int alpha = trackBarOpacity.Value;

            Layer.Color = new XNAColor(red, green, blue, alpha);

            DialogResult = DialogResult.OK;
        }


        /// <summary>
        /// Event handler for the red component track bar
        /// </summary>
        void TrackBarRedChanged(object sender, EventArgs e)
        {
            textBoxRed.Text = trackBarRed.Value.ToString();
        }


        /// <summary>
        /// Event handler for the green component track bar
        /// </summary>
        void TrackBarGreenChanged(object sender, EventArgs e)
        {
            textBoxGreen.Text = trackBarGreen.Value.ToString();
        }


        /// <summary>
        /// Event handler for the blue component track bar
        /// </summary>
        void TrackBarBlueChanged(object sender, EventArgs e)
        {
            textBoxBlue.Text = trackBarBlue.Value.ToString();
        }


        /// <summary>
        /// Event handler for the alpha component track bar
        /// </summary>
        void TrackBarOpacityChanged(object sender, EventArgs e)
        {
            textBoxOpacity.Text = trackBarOpacity.Value.ToString();
        }


        /// <summary>
        /// Event handler for the red component text box
        /// </summary>
        void TextRedChanged(object sender, EventArgs e)
        {
            try
            {
                int red = int.Parse(textBoxRed.Text);
                if (red < 0 || red > 255) { MessageBox.Show("Red must be an integer value between 0 and 255", "Error"); return; }
                trackBarRed.Value = red;
            }
            catch { MessageBox.Show("Red must be an integer value between 0 and 255", "Error"); return; }
        }


        /// <summary>
        /// Event handler for the green component text box
        /// </summary>
        void TextGreenChanged(object sender, EventArgs e)
        {
            try
            {
                int green = int.Parse(textBoxGreen.Text);
                if (green < 0 || green > 255) { MessageBox.Show("Green must be an integer value between 0 and 255", "Error"); return; }
                trackBarGreen.Value = green;
            }
            catch { MessageBox.Show("Green must be an integer value between 0 and 255", "Error"); return; }
        }


        /// <summary>
        /// Event handler for the blue component text box
        /// </summary>
        void TextBlueChanged(object sender, EventArgs e)
        {
            try
            {
                int blue = int.Parse(textBoxBlue.Text);
                if (blue < 0 || blue > 255) { MessageBox.Show("Blue must be an integer value between 0 and 255", "Error"); return; }
                trackBarBlue.Value = blue;
            }
            catch { MessageBox.Show("Blue must be an integer value between 0 and 255", "Error"); return; }
        }


        /// <summary>
        /// Event handler for the alpha component text box
        /// </summary>
        void TextOpacityChanged(object sender, EventArgs e)
        {
            try
            {
                int alpha = int.Parse(textBoxOpacity.Text);
                if (alpha < 0 || alpha > 255) { MessageBox.Show("Alpha must be an integer value between 0 and 255", "Error"); return; }
                trackBarOpacity.Value = alpha;
            }
            catch { MessageBox.Show("Alpha must be an integer value between 0 and 255", "Error"); return; }
        }

        #endregion
    }
}
