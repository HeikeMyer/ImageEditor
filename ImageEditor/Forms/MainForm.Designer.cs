namespace ImageEditor.Forms
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
            this.topToolStrip = new System.Windows.Forms.ToolStrip();
            this.fileToolStripDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageToolStripDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adjustmentsStripDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.brightnessContrastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorBalanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.photoFilterToolStripDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.erosionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dilutionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterToolStripDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.sepiaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blackAndWhiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thresholdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exposureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sharpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sharpenMoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unsharpMaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.boxBlurToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gaussianBlurToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.edgeDetectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.topToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // topToolStrip
            // 
            this.topToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.topToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripDropDownButton,
            this.imageToolStripDropDownButton,
            this.adjustmentsStripDropDownButton,
            this.photoFilterToolStripDropDownButton,
            this.filterToolStripDropDownButton});
            this.topToolStrip.Location = new System.Drawing.Point(0, 0);
            this.topToolStrip.Name = "topToolStrip";
            this.topToolStrip.Size = new System.Drawing.Size(1183, 27);
            this.topToolStrip.TabIndex = 0;
            this.topToolStrip.Text = "toolStrip1";
            this.topToolStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.topToolStrip_ItemClicked);
            // 
            // fileToolStripDropDownButton
            // 
            this.fileToolStripDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.fileToolStripDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripDropDownButton.Image = ((System.Drawing.Image)(resources.GetObject("fileToolStripDropDownButton.Image")));
            this.fileToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fileToolStripDropDownButton.Name = "fileToolStripDropDownButton";
            this.fileToolStripDropDownButton.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripDropDownButton.Text = "File";
            this.fileToolStripDropDownButton.ToolTipText = "File";
            this.fileToolStripDropDownButton.Click += new System.EventHandler(this.toolStripDropDownButton1_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.openToolStripMenuItem.Text = "Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.saveAsToolStripMenuItem.Text = "Save as...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // imageToolStripDropDownButton
            // 
            this.imageToolStripDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.imageToolStripDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem});
            this.imageToolStripDropDownButton.Image = ((System.Drawing.Image)(resources.GetObject("imageToolStripDropDownButton.Image")));
            this.imageToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.imageToolStripDropDownButton.Name = "imageToolStripDropDownButton";
            this.imageToolStripDropDownButton.Size = new System.Drawing.Size(65, 24);
            this.imageToolStripDropDownButton.Text = "Image";
            this.imageToolStripDropDownButton.Click += new System.EventHandler(this.imageToolStripDropDownButton_Click);
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(120, 26);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // adjustmentsStripDropDownButton
            // 
            this.adjustmentsStripDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.adjustmentsStripDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.brightnessContrastToolStripMenuItem,
            this.colorBalanceToolStripMenuItem});
            this.adjustmentsStripDropDownButton.Image = ((System.Drawing.Image)(resources.GetObject("adjustmentsStripDropDownButton.Image")));
            this.adjustmentsStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.adjustmentsStripDropDownButton.Name = "adjustmentsStripDropDownButton";
            this.adjustmentsStripDropDownButton.Size = new System.Drawing.Size(105, 24);
            this.adjustmentsStripDropDownButton.Text = "Adjustments";
            this.adjustmentsStripDropDownButton.Click += new System.EventHandler(this.adjustmentsStripDropDownButton_Click);
            // 
            // brightnessContrastToolStripMenuItem
            // 
            this.brightnessContrastToolStripMenuItem.Name = "brightnessContrastToolStripMenuItem";
            this.brightnessContrastToolStripMenuItem.Size = new System.Drawing.Size(207, 26);
            this.brightnessContrastToolStripMenuItem.Text = "brightnessContrast";
            this.brightnessContrastToolStripMenuItem.Click += new System.EventHandler(this.brightnessContrastToolStripMenuItem_Click);
            // 
            // colorBalanceToolStripMenuItem
            // 
            this.colorBalanceToolStripMenuItem.Name = "colorBalanceToolStripMenuItem";
            this.colorBalanceToolStripMenuItem.Size = new System.Drawing.Size(207, 26);
            this.colorBalanceToolStripMenuItem.Text = "colorBalance";
            this.colorBalanceToolStripMenuItem.Click += new System.EventHandler(this.colorBalanceToolStripMenuItem_Click);
            // 
            // photoFilterToolStripDropDownButton
            // 
            this.photoFilterToolStripDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.photoFilterToolStripDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.erosionToolStripMenuItem,
            this.dilutionToolStripMenuItem,
            this.invertToolStripMenuItem});
            this.photoFilterToolStripDropDownButton.Image = ((System.Drawing.Image)(resources.GetObject("photoFilterToolStripDropDownButton.Image")));
            this.photoFilterToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.photoFilterToolStripDropDownButton.Name = "photoFilterToolStripDropDownButton";
            this.photoFilterToolStripDropDownButton.Size = new System.Drawing.Size(99, 24);
            this.photoFilterToolStripDropDownButton.Text = "Photo Filter";
            this.photoFilterToolStripDropDownButton.Click += new System.EventHandler(this.photoFilterToolStripDropDownButton_Click);
            // 
            // erosionToolStripMenuItem
            // 
            this.erosionToolStripMenuItem.Name = "erosionToolStripMenuItem";
            this.erosionToolStripMenuItem.Size = new System.Drawing.Size(135, 26);
            this.erosionToolStripMenuItem.Text = "erosion";
            this.erosionToolStripMenuItem.Click += new System.EventHandler(this.erosionToolStripMenuItem_Click);
            // 
            // dilutionToolStripMenuItem
            // 
            this.dilutionToolStripMenuItem.Name = "dilutionToolStripMenuItem";
            this.dilutionToolStripMenuItem.Size = new System.Drawing.Size(135, 26);
            this.dilutionToolStripMenuItem.Text = "dilution";
            this.dilutionToolStripMenuItem.Click += new System.EventHandler(this.dilutionToolStripMenuItem_Click);
            // 
            // invertToolStripMenuItem
            // 
            this.invertToolStripMenuItem.Name = "invertToolStripMenuItem";
            this.invertToolStripMenuItem.Size = new System.Drawing.Size(135, 26);
            this.invertToolStripMenuItem.Text = "invert";
            this.invertToolStripMenuItem.Click += new System.EventHandler(this.invertToolStripMenuItem_Click);
            // 
            // filterToolStripDropDownButton
            // 
            this.filterToolStripDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.filterToolStripDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sepiaToolStripMenuItem,
            this.blackAndWhiteToolStripMenuItem,
            this.thresholdToolStripMenuItem,
            this.exposureToolStripMenuItem,
            this.sharpenToolStripMenuItem,
            this.sharpenMoreToolStripMenuItem,
            this.unsharpMaskToolStripMenuItem,
            this.boxBlurToolStripMenuItem,
            this.gaussianBlurToolStripMenuItem,
            this.edgeDetectionToolStripMenuItem});
            this.filterToolStripDropDownButton.Image = ((System.Drawing.Image)(resources.GetObject("filterToolStripDropDownButton.Image")));
            this.filterToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.filterToolStripDropDownButton.Name = "filterToolStripDropDownButton";
            this.filterToolStripDropDownButton.Size = new System.Drawing.Size(56, 24);
            this.filterToolStripDropDownButton.Text = "Filter";
            this.filterToolStripDropDownButton.Click += new System.EventHandler(this.filterToolStripDropDownButton_Click);
            // 
            // sepiaToolStripMenuItem
            // 
            this.sepiaToolStripMenuItem.Name = "sepiaToolStripMenuItem";
            this.sepiaToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.sepiaToolStripMenuItem.Text = "sepia";
            this.sepiaToolStripMenuItem.Click += new System.EventHandler(this.sepiaToolStripMenuItem_Click);
            // 
            // blackAndWhiteToolStripMenuItem
            // 
            this.blackAndWhiteToolStripMenuItem.Name = "blackAndWhiteToolStripMenuItem";
            this.blackAndWhiteToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.blackAndWhiteToolStripMenuItem.Text = "blackAndWhite";
            this.blackAndWhiteToolStripMenuItem.Click += new System.EventHandler(this.blackAndWhiteToolStripMenuItem_Click);
            // 
            // thresholdToolStripMenuItem
            // 
            this.thresholdToolStripMenuItem.Name = "thresholdToolStripMenuItem";
            this.thresholdToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.thresholdToolStripMenuItem.Text = "threshold";
            this.thresholdToolStripMenuItem.Click += new System.EventHandler(this.thresholdToolStripMenuItem_Click);
            // 
            // exposureToolStripMenuItem
            // 
            this.exposureToolStripMenuItem.Name = "exposureToolStripMenuItem";
            this.exposureToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.exposureToolStripMenuItem.Text = "exposure";
            this.exposureToolStripMenuItem.Click += new System.EventHandler(this.exposureToolStripMenuItem_Click);
            // 
            // sharpenToolStripMenuItem
            // 
            this.sharpenToolStripMenuItem.Name = "sharpenToolStripMenuItem";
            this.sharpenToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.sharpenToolStripMenuItem.Text = "sharpen";
            this.sharpenToolStripMenuItem.Click += new System.EventHandler(this.sharpenToolStripMenuItem_Click);
            // 
            // sharpenMoreToolStripMenuItem
            // 
            this.sharpenMoreToolStripMenuItem.Name = "sharpenMoreToolStripMenuItem";
            this.sharpenMoreToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.sharpenMoreToolStripMenuItem.Text = "sharpenMore";
            this.sharpenMoreToolStripMenuItem.Click += new System.EventHandler(this.sharpenMoreToolStripMenuItem_Click);
            // 
            // unsharpMaskToolStripMenuItem
            // 
            this.unsharpMaskToolStripMenuItem.Name = "unsharpMaskToolStripMenuItem";
            this.unsharpMaskToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.unsharpMaskToolStripMenuItem.Text = "unsharpMask";
            this.unsharpMaskToolStripMenuItem.Click += new System.EventHandler(this.unsharpMaskToolStripMenuItem_Click);
            // 
            // boxBlurToolStripMenuItem
            // 
            this.boxBlurToolStripMenuItem.Name = "boxBlurToolStripMenuItem";
            this.boxBlurToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.boxBlurToolStripMenuItem.Text = "boxBlur";
            this.boxBlurToolStripMenuItem.Click += new System.EventHandler(this.boxBlurToolStripMenuItem_Click);
            // 
            // gaussianBlurToolStripMenuItem
            // 
            this.gaussianBlurToolStripMenuItem.Name = "gaussianBlurToolStripMenuItem";
            this.gaussianBlurToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.gaussianBlurToolStripMenuItem.Text = "gaussianBlur";
            this.gaussianBlurToolStripMenuItem.Click += new System.EventHandler(this.gaussianBlurToolStripMenuItem_Click);
            // 
            // edgeDetectionToolStripMenuItem
            // 
            this.edgeDetectionToolStripMenuItem.Name = "edgeDetectionToolStripMenuItem";
            this.edgeDetectionToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.edgeDetectionToolStripMenuItem.Text = "edgeDetection";
            this.edgeDetectionToolStripMenuItem.Click += new System.EventHandler(this.edgeDetectionToolStripMenuItem_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(0, 27);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Padding = new System.Windows.Forms.Padding(25);
            this.pictureBox.Size = new System.Drawing.Size(1183, 423);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            this.pictureBox.Click += new System.EventHandler(this.pictureBox_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1183, 450);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.topToolStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Image Editor";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.topToolStrip.ResumeLayout(false);
            this.topToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip topToolStrip;
        private System.Windows.Forms.ToolStripDropDownButton fileToolStripDropDownButton;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton imageToolStripDropDownButton;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton adjustmentsStripDropDownButton;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.ToolStripDropDownButton photoFilterToolStripDropDownButton;
        private System.Windows.Forms.ToolStripDropDownButton filterToolStripDropDownButton;
        private System.Windows.Forms.ToolStripMenuItem brightnessContrastToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorBalanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem erosionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dilutionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sepiaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blackAndWhiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thresholdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exposureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sharpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sharpenMoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unsharpMaskToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem boxBlurToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gaussianBlurToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem edgeDetectionToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
    }
}