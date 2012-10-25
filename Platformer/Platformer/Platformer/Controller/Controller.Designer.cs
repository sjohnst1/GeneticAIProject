namespace Platformer.Controller
{
    partial class Controller
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
            this.btStart = new System.Windows.Forms.Button();
            this.btStop = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.inWeightFile = new System.Windows.Forms.TextBox();
            this.btBrowse = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.inGenerations = new System.Windows.Forms.NumericUpDown();
            this.inRunForever = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.inBetweenWrites = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.inGenerations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inBetweenWrites)).BeginInit();
            this.SuspendLayout();
            // 
            // btStart
            // 
            this.btStart.Location = new System.Drawing.Point(112, 218);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(75, 23);
            this.btStart.TabIndex = 0;
            this.btStart.Text = "Start";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // btStop
            // 
            this.btStop.Location = new System.Drawing.Point(218, 218);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(75, 23);
            this.btStop.TabIndex = 1;
            this.btStop.Text = "Stop";
            this.btStop.UseVisualStyleBackColor = true;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Title = "Choose File";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Weight File:";
            // 
            // inWeightFile
            // 
            this.inWeightFile.Location = new System.Drawing.Point(81, 12);
            this.inWeightFile.Name = "inWeightFile";
            this.inWeightFile.Size = new System.Drawing.Size(197, 20);
            this.inWeightFile.TabIndex = 3;
            // 
            // btBrowse
            // 
            this.btBrowse.Location = new System.Drawing.Point(284, 10);
            this.btBrowse.Name = "btBrowse";
            this.btBrowse.Size = new System.Drawing.Size(75, 23);
            this.btBrowse.TabIndex = 4;
            this.btBrowse.Text = "Browse";
            this.btBrowse.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Number of Generations:";
            // 
            // inGenerations
            // 
            this.inGenerations.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.inGenerations.Location = new System.Drawing.Point(137, 54);
            this.inGenerations.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.inGenerations.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.inGenerations.Name = "inGenerations";
            this.inGenerations.Size = new System.Drawing.Size(88, 20);
            this.inGenerations.TabIndex = 6;
            this.inGenerations.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // inRunForever
            // 
            this.inRunForever.AutoSize = true;
            this.inRunForever.Location = new System.Drawing.Point(231, 55);
            this.inRunForever.Name = "inRunForever";
            this.inRunForever.Size = new System.Drawing.Size(113, 17);
            this.inRunForever.TabIndex = 7;
            this.inRunForever.Text = "Run Until Stopped";
            this.inRunForever.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Generations Between File Write:";
            // 
            // inBetweenWrites
            // 
            this.inBetweenWrites.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.inBetweenWrites.Location = new System.Drawing.Point(177, 89);
            this.inBetweenWrites.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.inBetweenWrites.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.inBetweenWrites.Name = "inBetweenWrites";
            this.inBetweenWrites.Size = new System.Drawing.Size(90, 20);
            this.inBetweenWrites.TabIndex = 9;
            this.inBetweenWrites.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Controller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 262);
            this.Controls.Add(this.inBetweenWrites);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.inRunForever);
            this.Controls.Add(this.inGenerations);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btBrowse);
            this.Controls.Add(this.inWeightFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btStop);
            this.Controls.Add(this.btStart);
            this.Name = "Controller";
            this.Text = "Controller";
            ((System.ComponentModel.ISupportInitialize)(this.inGenerations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inBetweenWrites)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox inWeightFile;
        private System.Windows.Forms.Button btBrowse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown inGenerations;
        private System.Windows.Forms.CheckBox inRunForever;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown inBetweenWrites;
    }
}