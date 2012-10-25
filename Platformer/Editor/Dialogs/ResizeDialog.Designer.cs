namespace Editor
{
    partial class ResizeDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResizeDialog));
            this.textBoxWidth = new System.Windows.Forms.TextBox();
            this.textBoxHeight = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.radioButtonTL = new System.Windows.Forms.RadioButton();
            this.radioButtonTC = new System.Windows.Forms.RadioButton();
            this.radioButtonTR = new System.Windows.Forms.RadioButton();
            this.radioButtonCR = new System.Windows.Forms.RadioButton();
            this.radioButtonC = new System.Windows.Forms.RadioButton();
            this.radioButtonCL = new System.Windows.Forms.RadioButton();
            this.radioButtonBR = new System.Windows.Forms.RadioButton();
            this.radioButtonBC = new System.Windows.Forms.RadioButton();
            this.radioButtonBL = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // textBoxWidth
            // 
            this.textBoxWidth.Location = new System.Drawing.Point(141, 13);
            this.textBoxWidth.Name = "textBoxWidth";
            this.textBoxWidth.Size = new System.Drawing.Size(40, 22);
            this.textBoxWidth.TabIndex = 9;
            // 
            // textBoxHeight
            // 
            this.textBoxHeight.Location = new System.Drawing.Point(141, 41);
            this.textBoxHeight.Name = "textBoxHeight";
            this.textBoxHeight.Size = new System.Drawing.Size(40, 22);
            this.textBoxHeight.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "Width";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(79, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "Height";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(79, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "Anchor";
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(60, 254);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 14;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(141, 254);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 15;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // radioButtonTL
            // 
            this.radioButtonTL.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButtonTL.AutoSize = true;
            this.radioButtonTL.Checked = true;
            this.radioButtonTL.Image = ((System.Drawing.Image)(resources.GetObject("radioButtonTL.Image")));
            this.radioButtonTL.Location = new System.Drawing.Point(82, 102);
            this.radioButtonTL.Name = "radioButtonTL";
            this.radioButtonTL.Size = new System.Drawing.Size(38, 38);
            this.radioButtonTL.TabIndex = 16;
            this.radioButtonTL.TabStop = true;
            this.radioButtonTL.UseVisualStyleBackColor = true;
            this.radioButtonTL.CheckedChanged += new System.EventHandler(this.radioButtonTL_CheckedChanged);
            // 
            // radioButtonTC
            // 
            this.radioButtonTC.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButtonTC.AutoSize = true;
            this.radioButtonTC.Image = ((System.Drawing.Image)(resources.GetObject("radioButtonTC.Image")));
            this.radioButtonTC.Location = new System.Drawing.Point(126, 102);
            this.radioButtonTC.Name = "radioButtonTC";
            this.radioButtonTC.Size = new System.Drawing.Size(38, 38);
            this.radioButtonTC.TabIndex = 17;
            this.radioButtonTC.UseVisualStyleBackColor = true;
            this.radioButtonTC.CheckedChanged += new System.EventHandler(this.radioButtonTC_CheckedChanged);
            // 
            // radioButtonTR
            // 
            this.radioButtonTR.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButtonTR.AutoSize = true;
            this.radioButtonTR.Image = ((System.Drawing.Image)(resources.GetObject("radioButtonTR.Image")));
            this.radioButtonTR.Location = new System.Drawing.Point(170, 102);
            this.radioButtonTR.Name = "radioButtonTR";
            this.radioButtonTR.Size = new System.Drawing.Size(38, 38);
            this.radioButtonTR.TabIndex = 18;
            this.radioButtonTR.UseVisualStyleBackColor = true;
            this.radioButtonTR.CheckedChanged += new System.EventHandler(this.radioButtonTR_CheckedChanged);
            // 
            // radioButtonCR
            // 
            this.radioButtonCR.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButtonCR.AutoSize = true;
            this.radioButtonCR.Image = ((System.Drawing.Image)(resources.GetObject("radioButtonCR.Image")));
            this.radioButtonCR.Location = new System.Drawing.Point(170, 146);
            this.radioButtonCR.Name = "radioButtonCR";
            this.radioButtonCR.Size = new System.Drawing.Size(38, 38);
            this.radioButtonCR.TabIndex = 21;
            this.radioButtonCR.UseVisualStyleBackColor = true;
            this.radioButtonCR.CheckedChanged += new System.EventHandler(this.radioButtonCR_CheckedChanged);
            // 
            // radioButtonC
            // 
            this.radioButtonC.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButtonC.AutoSize = true;
            this.radioButtonC.Image = ((System.Drawing.Image)(resources.GetObject("radioButtonC.Image")));
            this.radioButtonC.Location = new System.Drawing.Point(126, 146);
            this.radioButtonC.Name = "radioButtonC";
            this.radioButtonC.Size = new System.Drawing.Size(38, 38);
            this.radioButtonC.TabIndex = 20;
            this.radioButtonC.UseVisualStyleBackColor = true;
            this.radioButtonC.CheckedChanged += new System.EventHandler(this.radioButtonC_CheckedChanged);
            // 
            // radioButtonCL
            // 
            this.radioButtonCL.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButtonCL.AutoSize = true;
            this.radioButtonCL.Image = ((System.Drawing.Image)(resources.GetObject("radioButtonCL.Image")));
            this.radioButtonCL.Location = new System.Drawing.Point(82, 146);
            this.radioButtonCL.Name = "radioButtonCL";
            this.radioButtonCL.Size = new System.Drawing.Size(38, 38);
            this.radioButtonCL.TabIndex = 19;
            this.radioButtonCL.UseVisualStyleBackColor = true;
            this.radioButtonCL.CheckedChanged += new System.EventHandler(this.radioButtonCL_CheckedChanged);
            // 
            // radioButtonBR
            // 
            this.radioButtonBR.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButtonBR.AutoSize = true;
            this.radioButtonBR.Image = ((System.Drawing.Image)(resources.GetObject("radioButtonBR.Image")));
            this.radioButtonBR.Location = new System.Drawing.Point(170, 190);
            this.radioButtonBR.Name = "radioButtonBR";
            this.radioButtonBR.Size = new System.Drawing.Size(38, 38);
            this.radioButtonBR.TabIndex = 24;
            this.radioButtonBR.UseVisualStyleBackColor = true;
            this.radioButtonBR.CheckedChanged += new System.EventHandler(this.radioButtonBR_CheckedChanged);
            // 
            // radioButtonBC
            // 
            this.radioButtonBC.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButtonBC.AutoSize = true;
            this.radioButtonBC.Image = ((System.Drawing.Image)(resources.GetObject("radioButtonBC.Image")));
            this.radioButtonBC.Location = new System.Drawing.Point(126, 190);
            this.radioButtonBC.Name = "radioButtonBC";
            this.radioButtonBC.Size = new System.Drawing.Size(38, 38);
            this.radioButtonBC.TabIndex = 23;
            this.radioButtonBC.UseVisualStyleBackColor = true;
            this.radioButtonBC.CheckedChanged += new System.EventHandler(this.radioButtonBC_CheckedChanged);
            // 
            // radioButtonBL
            // 
            this.radioButtonBL.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButtonBL.AutoSize = true;
            this.radioButtonBL.Image = ((System.Drawing.Image)(resources.GetObject("radioButtonBL.Image")));
            this.radioButtonBL.Location = new System.Drawing.Point(82, 190);
            this.radioButtonBL.Name = "radioButtonBL";
            this.radioButtonBL.Size = new System.Drawing.Size(38, 38);
            this.radioButtonBL.TabIndex = 22;
            this.radioButtonBL.UseVisualStyleBackColor = true;
            this.radioButtonBL.CheckedChanged += new System.EventHandler(this.radioButtonBL_CheckedChanged);
            // 
            // ResizeDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 304);
            this.Controls.Add(this.radioButtonBR);
            this.Controls.Add(this.radioButtonBC);
            this.Controls.Add(this.radioButtonBL);
            this.Controls.Add(this.radioButtonCR);
            this.Controls.Add(this.radioButtonC);
            this.Controls.Add(this.radioButtonCL);
            this.Controls.Add(this.radioButtonTR);
            this.Controls.Add(this.radioButtonTC);
            this.Controls.Add(this.radioButtonTL);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxHeight);
            this.Controls.Add(this.textBoxWidth);
            this.Name = "ResizeDialog";
            this.Text = "Resize Map";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxWidth;
        private System.Windows.Forms.TextBox textBoxHeight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.RadioButton radioButtonTL;
        private System.Windows.Forms.RadioButton radioButtonTC;
        private System.Windows.Forms.RadioButton radioButtonTR;
        private System.Windows.Forms.RadioButton radioButtonCR;
        private System.Windows.Forms.RadioButton radioButtonC;
        private System.Windows.Forms.RadioButton radioButtonCL;
        private System.Windows.Forms.RadioButton radioButtonBR;
        private System.Windows.Forms.RadioButton radioButtonBC;
        private System.Windows.Forms.RadioButton radioButtonBL;
    }
}