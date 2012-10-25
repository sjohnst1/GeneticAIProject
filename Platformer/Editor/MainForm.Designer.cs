namespace Editor
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newMapImageToolstripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadTilemapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveTilemapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newLayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resizeLayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newTileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importTilePaletteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportTilePaletteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileListView = new System.Windows.Forms.ListView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.mapViewerControl = new Editor.MapViewerControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonPaint = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonFill = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonPin = new System.Windows.Forms.ToolStripButton();
            this.hScrollBarMap = new System.Windows.Forms.HScrollBar();
            this.vScrollBarMap = new System.Windows.Forms.VScrollBar();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageTiles = new System.Windows.Forms.TabPage();
            this.tabPageObjects = new System.Windows.Forms.TabPage();
            this.objectListView = new System.Windows.Forms.ListView();
            this.listBoxLayers = new System.Windows.Forms.ListBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageTiles.SuspendLayout();
            this.tabPageObjects.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.mapToolStripMenuItem,
            this.tileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(792, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newMapImageToolstripMenuItem,
            this.loadTilemapToolStripMenuItem,
            this.saveTilemapToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newMapImageToolstripMenuItem
            // 
            this.newMapImageToolstripMenuItem.Name = "newMapImageToolstripMenuItem";
            this.newMapImageToolstripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.newMapImageToolstripMenuItem.Text = "New Tilemap...";
            // 
            // loadTilemapToolStripMenuItem
            // 
            this.loadTilemapToolStripMenuItem.Name = "loadTilemapToolStripMenuItem";
            this.loadTilemapToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.loadTilemapToolStripMenuItem.Text = "Load Tilemap...";
            // 
            // saveTilemapToolStripMenuItem
            // 
            this.saveTilemapToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.saveTilemapToolStripMenuItem.Name = "saveTilemapToolStripMenuItem";
            this.saveTilemapToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.saveTilemapToolStripMenuItem.Text = "Save Tilemap...";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitMenuClicked);
            // 
            // mapToolStripMenuItem
            // 
            this.mapToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newLayerToolStripMenuItem,
            this.resizeLayerToolStripMenuItem});
            this.mapToolStripMenuItem.Name = "mapToolStripMenuItem";
            this.mapToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.mapToolStripMenuItem.Text = "Layer";
            // 
            // newLayerToolStripMenuItem
            // 
            this.newLayerToolStripMenuItem.Name = "newLayerToolStripMenuItem";
            this.newLayerToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.newLayerToolStripMenuItem.Text = "New Layer";
            // 
            // resizeLayerToolStripMenuItem
            // 
            this.resizeLayerToolStripMenuItem.Name = "resizeLayerToolStripMenuItem";
            this.resizeLayerToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.resizeLayerToolStripMenuItem.Text = "Resize Layer...";
            // 
            // tileToolStripMenuItem
            // 
            this.tileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newTileToolStripMenuItem,
            this.importTilePaletteToolStripMenuItem,
            this.exportTilePaletteToolStripMenuItem});
            this.tileToolStripMenuItem.Name = "tileToolStripMenuItem";
            this.tileToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.tileToolStripMenuItem.Text = "Tiles";
            // 
            // newTileToolStripMenuItem
            // 
            this.newTileToolStripMenuItem.Name = "newTileToolStripMenuItem";
            this.newTileToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newTileToolStripMenuItem.Text = "New Tile...";
            // 
            // importTilePaletteToolStripMenuItem
            // 
            this.importTilePaletteToolStripMenuItem.Name = "importTilePaletteToolStripMenuItem";
            this.importTilePaletteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.importTilePaletteToolStripMenuItem.Text = "Import Tile Palette...";
            // 
            // exportTilePaletteToolStripMenuItem
            // 
            this.exportTilePaletteToolStripMenuItem.Name = "exportTilePaletteToolStripMenuItem";
            this.exportTilePaletteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exportTilePaletteToolStripMenuItem.Text = "Export Tile Palette...";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // tileListView
            // 
            this.tileListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tileListView.Location = new System.Drawing.Point(2, 2);
            this.tileListView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tileListView.Name = "tileListView";
            this.tileListView.Size = new System.Drawing.Size(154, 253);
            this.tileListView.TabIndex = 2;
            this.tileListView.UseCompatibleStateImageBehavior = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.toolStripContainer1);
            this.splitContainer1.Panel1.Controls.Add(this.hScrollBarMap);
            this.splitContainer1.Panel1.Controls.Add(this.vScrollBarMap);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(792, 549);
            this.splitContainer1.SplitterDistance = 623;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 3;
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.mapViewerControl);
            this.toolStripContainer1.ContentPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(602, 503);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(602, 528);
            this.toolStripContainer1.TabIndex = 5;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // mapViewerControl
            // 
            this.mapViewerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapViewerControl.Location = new System.Drawing.Point(0, 0);
            this.mapViewerControl.Name = "mapViewerControl";
            this.mapViewerControl.SelectedLayerIndex = 0;
            this.mapViewerControl.SelectedObjectIndex = 0;
            this.mapViewerControl.SelectedTileIndex = -1;
            this.mapViewerControl.Size = new System.Drawing.Size(602, 503);
            this.mapViewerControl.TabIndex = 1;
            this.mapViewerControl.Text = "mapViewerControl";
            this.mapViewerControl.ToolState = Editor.EditorToolState.Paint;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonPaint,
            this.toolStripButtonFill,
            this.toolStripButtonPin});
            this.toolStrip1.Location = new System.Drawing.Point(27, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(81, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonPaint
            // 
            this.toolStripButtonPaint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonPaint.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonPaint.Image")));
            this.toolStripButtonPaint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPaint.Name = "toolStripButtonPaint";
            this.toolStripButtonPaint.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonPaint.Text = "Paint";
            this.toolStripButtonPaint.ToolTipText = "Paint Tile";
            // 
            // toolStripButtonFill
            // 
            this.toolStripButtonFill.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonFill.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonFill.Image")));
            this.toolStripButtonFill.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonFill.Name = "toolStripButtonFill";
            this.toolStripButtonFill.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonFill.Text = "Fill";
            this.toolStripButtonFill.ToolTipText = "Fill Tiles";
            // 
            // toolStripButtonPin
            // 
            this.toolStripButtonPin.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonPin.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonPin.Image")));
            this.toolStripButtonPin.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPin.Name = "toolStripButtonPin";
            this.toolStripButtonPin.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonPin.Text = "Pin";
            this.toolStripButtonPin.ToolTipText = "Pin Object";
            // 
            // hScrollBarMap
            // 
            this.hScrollBarMap.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.hScrollBarMap.Location = new System.Drawing.Point(0, 528);
            this.hScrollBarMap.Name = "hScrollBarMap";
            this.hScrollBarMap.Size = new System.Drawing.Size(602, 21);
            this.hScrollBarMap.TabIndex = 3;
            // 
            // vScrollBarMap
            // 
            this.vScrollBarMap.Dock = System.Windows.Forms.DockStyle.Right;
            this.vScrollBarMap.Location = new System.Drawing.Point(602, 0);
            this.vScrollBarMap.Name = "vScrollBarMap";
            this.vScrollBarMap.Size = new System.Drawing.Size(21, 549);
            this.vScrollBarMap.TabIndex = 2;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.listBoxLayers);
            this.splitContainer2.Size = new System.Drawing.Size(166, 549);
            this.splitContainer2.SplitterDistance = 283;
            this.splitContainer2.SplitterWidth = 3;
            this.splitContainer2.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageTiles);
            this.tabControl1.Controls.Add(this.tabPageObjects);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(166, 283);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageTiles
            // 
            this.tabPageTiles.Controls.Add(this.tileListView);
            this.tabPageTiles.Location = new System.Drawing.Point(4, 22);
            this.tabPageTiles.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPageTiles.Name = "tabPageTiles";
            this.tabPageTiles.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPageTiles.Size = new System.Drawing.Size(158, 257);
            this.tabPageTiles.TabIndex = 0;
            this.tabPageTiles.Text = "Tiles";
            this.tabPageTiles.UseVisualStyleBackColor = true;
            // 
            // tabPageObjects
            // 
            this.tabPageObjects.Controls.Add(this.objectListView);
            this.tabPageObjects.Location = new System.Drawing.Point(4, 22);
            this.tabPageObjects.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPageObjects.Name = "tabPageObjects";
            this.tabPageObjects.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPageObjects.Size = new System.Drawing.Size(158, 257);
            this.tabPageObjects.TabIndex = 1;
            this.tabPageObjects.Text = "Objects";
            this.tabPageObjects.UseVisualStyleBackColor = true;
            // 
            // objectListView
            // 
            this.objectListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objectListView.Location = new System.Drawing.Point(2, 2);
            this.objectListView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.objectListView.Name = "objectListView";
            this.objectListView.Size = new System.Drawing.Size(154, 253);
            this.objectListView.TabIndex = 0;
            this.objectListView.UseCompatibleStateImageBehavior = false;
            // 
            // listBoxLayers
            // 
            this.listBoxLayers.AllowDrop = true;
            this.listBoxLayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxLayers.FormattingEnabled = true;
            this.listBoxLayers.Location = new System.Drawing.Point(0, 0);
            this.listBoxLayers.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listBoxLayers.Name = "listBoxLayers";
            this.listBoxLayers.Size = new System.Drawing.Size(166, 263);
            this.listBoxLayers.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Platformer Game Editor";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPageTiles.ResumeLayout(false);
            this.tabPageObjects.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private Editor.MapViewerControl mapViewerControl;
        private System.Windows.Forms.ListView tileListView;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripMenuItem mapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newMapImageToolstripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resizeLayerToolStripMenuItem;
        private System.Windows.Forms.HScrollBar hScrollBarMap;
        private System.Windows.Forms.VScrollBar vScrollBarMap;
        private System.Windows.Forms.ToolStripMenuItem newTileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveTilemapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadTilemapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importTilePaletteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportTilePaletteToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonPaint;
        private System.Windows.Forms.ToolStripButton toolStripButtonFill;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListBox listBoxLayers;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStripMenuItem newLayerToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageTiles;
        private System.Windows.Forms.TabPage tabPageObjects;
        private System.Windows.Forms.ListView objectListView;
        private System.Windows.Forms.ToolStripButton toolStripButtonPin;

    }
}

