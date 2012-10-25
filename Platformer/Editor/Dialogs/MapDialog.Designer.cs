namespace Editor
{
    partial class MapDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxMapWidth = new System.Windows.Forms.TextBox();
            this.textBoxMapHeight = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.textBoxTileWidth = new System.Windows.Forms.TextBox();
            this.textBoxTileHeight = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxMapName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxLayers = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxMapWidth
            // 
            this.textBoxMapWidth.Location = new System.Drawing.Point(186, 96);
            this.textBoxMapWidth.Name = "textBoxMapWidth";
            this.textBoxMapWidth.Size = new System.Drawing.Size(55, 22);
            this.textBoxMapWidth.TabIndex = 0;
            this.textBoxMapWidth.Text = "100";
            // 
            // textBoxMapHeight
            // 
            this.textBoxMapHeight.Location = new System.Drawing.Point(186, 124);
            this.textBoxMapHeight.Name = "textBoxMapHeight";
            this.textBoxMapHeight.Size = new System.Drawing.Size(55, 22);
            this.textBoxMapHeight.TabIndex = 1;
            this.textBoxMapHeight.Text = "100";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(100, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Map Width";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(95, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Map Height";
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(183, 232);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 4;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(100, 231);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // textBoxTileWidth
            // 
            this.textBoxTileWidth.Location = new System.Drawing.Point(186, 153);
            this.textBoxTileWidth.Name = "textBoxTileWidth";
            this.textBoxTileWidth.Size = new System.Drawing.Size(55, 22);
            this.textBoxTileWidth.TabIndex = 6;
            this.textBoxTileWidth.Text = "50";
            // 
            // textBoxTileHeight
            // 
            this.textBoxTileHeight.Location = new System.Drawing.Point(186, 182);
            this.textBoxTileHeight.Name = "textBoxTileHeight";
            this.textBoxTileHeight.Size = new System.Drawing.Size(55, 22);
            this.textBoxTileHeight.TabIndex = 7;
            this.textBoxTileHeight.Text = "50";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(100, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Tile Height";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(105, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Tile Width";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(75, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Map Name";
            // 
            // textBoxMapName
            // 
            this.textBoxMapName.Location = new System.Drawing.Point(162, 27);
            this.textBoxMapName.Name = "textBoxMapName";
            this.textBoxMapName.Size = new System.Drawing.Size(174, 22);
            this.textBoxMapName.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(93, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "Map Layers";
            // 
            // textBoxLayers
            // 
            this.textBoxLayers.Location = new System.Drawing.Point(186, 68);
            this.textBoxLayers.Name = "textBoxLayers";
            this.textBoxLayers.Size = new System.Drawing.Size(55, 22);
            this.textBoxLayers.TabIndex = 13;
            this.textBoxLayers.Text = "1";
            // 
            // MapDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 301);
            this.Controls.Add(this.textBoxLayers);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxMapName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxTileHeight);
            this.Controls.Add(this.textBoxTileWidth);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxMapHeight);
            this.Controls.Add(this.textBoxMapWidth);
            this.Name = "MapDialog";
            this.Text = "New Map...";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxMapWidth;
        private System.Windows.Forms.TextBox textBoxMapHeight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox textBoxTileWidth;
        private System.Windows.Forms.TextBox textBoxTileHeight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxMapName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxLayers;
    }
}