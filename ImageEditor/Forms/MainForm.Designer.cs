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
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageToolStripDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.adjustmentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.brightnessContrastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exposureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorBalanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thresholdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blackAndWhiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.photoFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sepiaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterToolStripDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.blurToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.boxBlurToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dilutionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gaussianBlurToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sharpenToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.erosionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sharpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sharpenMoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unsharpMaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stylizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.edgeDetectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.russianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.topToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // topToolStrip
            // 
            resources.ApplyResources(this.topToolStrip, "topToolStrip");
            this.topToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.topToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripDropDownButton,
            this.imageToolStripDropDownButton,
            this.filterToolStripDropDownButton,
            this.settingsToolStripDropDownButton});
            this.topToolStrip.Name = "topToolStrip";
            this.topToolStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.topToolStrip_ItemClicked);
            // 
            // fileToolStripDropDownButton
            // 
            resources.ApplyResources(this.fileToolStripDropDownButton, "fileToolStripDropDownButton");
            this.fileToolStripDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.fileToolStripDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.undoToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripDropDownButton.Name = "fileToolStripDropDownButton";
            this.fileToolStripDropDownButton.Click += new System.EventHandler(this.toolStripDropDownButton1_Click);
            // 
            // openToolStripMenuItem
            // 
            resources.ApplyResources(this.openToolStripMenuItem, "openToolStripMenuItem");
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // undoToolStripMenuItem
            // 
            resources.ApplyResources(this.undoToolStripMenuItem, "undoToolStripMenuItem");
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            // 
            // saveAsToolStripMenuItem
            // 
            resources.ApplyResources(this.saveAsToolStripMenuItem, "saveAsToolStripMenuItem");
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            resources.ApplyResources(this.closeToolStripMenuItem, "closeToolStripMenuItem");
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // imageToolStripDropDownButton
            // 
            resources.ApplyResources(this.imageToolStripDropDownButton, "imageToolStripDropDownButton");
            this.imageToolStripDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.imageToolStripDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adjustmentsToolStripMenuItem});
            this.imageToolStripDropDownButton.Name = "imageToolStripDropDownButton";
            this.imageToolStripDropDownButton.Click += new System.EventHandler(this.imageToolStripDropDownButton_Click);
            // 
            // adjustmentsToolStripMenuItem
            // 
            resources.ApplyResources(this.adjustmentsToolStripMenuItem, "adjustmentsToolStripMenuItem");
            this.adjustmentsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.brightnessContrastToolStripMenuItem,
            this.exposureToolStripMenuItem,
            this.colorBalanceToolStripMenuItem,
            this.thresholdToolStripMenuItem,
            this.blackAndWhiteToolStripMenuItem,
            this.invertToolStripMenuItem,
            this.photoFilterToolStripMenuItem});
            this.adjustmentsToolStripMenuItem.Name = "adjustmentsToolStripMenuItem";
            // 
            // brightnessContrastToolStripMenuItem
            // 
            resources.ApplyResources(this.brightnessContrastToolStripMenuItem, "brightnessContrastToolStripMenuItem");
            this.brightnessContrastToolStripMenuItem.Name = "brightnessContrastToolStripMenuItem";
            this.brightnessContrastToolStripMenuItem.Click += new System.EventHandler(this.brightnessContrastToolStripMenuItem_Click);
            // 
            // exposureToolStripMenuItem
            // 
            resources.ApplyResources(this.exposureToolStripMenuItem, "exposureToolStripMenuItem");
            this.exposureToolStripMenuItem.Name = "exposureToolStripMenuItem";
            this.exposureToolStripMenuItem.Click += new System.EventHandler(this.exposureToolStripMenuItem_Click);
            // 
            // colorBalanceToolStripMenuItem
            // 
            resources.ApplyResources(this.colorBalanceToolStripMenuItem, "colorBalanceToolStripMenuItem");
            this.colorBalanceToolStripMenuItem.Name = "colorBalanceToolStripMenuItem";
            this.colorBalanceToolStripMenuItem.Click += new System.EventHandler(this.colorBalanceToolStripMenuItem_Click);
            // 
            // thresholdToolStripMenuItem
            // 
            resources.ApplyResources(this.thresholdToolStripMenuItem, "thresholdToolStripMenuItem");
            this.thresholdToolStripMenuItem.Name = "thresholdToolStripMenuItem";
            this.thresholdToolStripMenuItem.Click += new System.EventHandler(this.thresholdToolStripMenuItem_Click);
            // 
            // blackAndWhiteToolStripMenuItem
            // 
            resources.ApplyResources(this.blackAndWhiteToolStripMenuItem, "blackAndWhiteToolStripMenuItem");
            this.blackAndWhiteToolStripMenuItem.Name = "blackAndWhiteToolStripMenuItem";
            this.blackAndWhiteToolStripMenuItem.Click += new System.EventHandler(this.blackAndWhiteToolStripMenuItem_Click);
            // 
            // invertToolStripMenuItem
            // 
            resources.ApplyResources(this.invertToolStripMenuItem, "invertToolStripMenuItem");
            this.invertToolStripMenuItem.Name = "invertToolStripMenuItem";
            this.invertToolStripMenuItem.Click += new System.EventHandler(this.invertToolStripMenuItem_Click);
            // 
            // photoFilterToolStripMenuItem
            // 
            resources.ApplyResources(this.photoFilterToolStripMenuItem, "photoFilterToolStripMenuItem");
            this.photoFilterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sepiaToolStripMenuItem});
            this.photoFilterToolStripMenuItem.Name = "photoFilterToolStripMenuItem";
            // 
            // sepiaToolStripMenuItem
            // 
            resources.ApplyResources(this.sepiaToolStripMenuItem, "sepiaToolStripMenuItem");
            this.sepiaToolStripMenuItem.Name = "sepiaToolStripMenuItem";
            this.sepiaToolStripMenuItem.Click += new System.EventHandler(this.sepiaToolStripMenuItem_Click);
            // 
            // filterToolStripDropDownButton
            // 
            resources.ApplyResources(this.filterToolStripDropDownButton, "filterToolStripDropDownButton");
            this.filterToolStripDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.filterToolStripDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.blurToolStripMenuItem,
            this.sharpenToolStripMenuItem1,
            this.stylizeToolStripMenuItem});
            this.filterToolStripDropDownButton.Name = "filterToolStripDropDownButton";
            this.filterToolStripDropDownButton.Click += new System.EventHandler(this.filterToolStripDropDownButton_Click);
            // 
            // blurToolStripMenuItem
            // 
            resources.ApplyResources(this.blurToolStripMenuItem, "blurToolStripMenuItem");
            this.blurToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.boxBlurToolStripMenuItem,
            this.dilutionToolStripMenuItem,
            this.gaussianBlurToolStripMenuItem});
            this.blurToolStripMenuItem.Name = "blurToolStripMenuItem";
            // 
            // boxBlurToolStripMenuItem
            // 
            resources.ApplyResources(this.boxBlurToolStripMenuItem, "boxBlurToolStripMenuItem");
            this.boxBlurToolStripMenuItem.Name = "boxBlurToolStripMenuItem";
            this.boxBlurToolStripMenuItem.Click += new System.EventHandler(this.boxBlurToolStripMenuItem_Click);
            // 
            // dilutionToolStripMenuItem
            // 
            resources.ApplyResources(this.dilutionToolStripMenuItem, "dilutionToolStripMenuItem");
            this.dilutionToolStripMenuItem.Name = "dilutionToolStripMenuItem";
            this.dilutionToolStripMenuItem.Click += new System.EventHandler(this.dilutionToolStripMenuItem_Click);
            // 
            // gaussianBlurToolStripMenuItem
            // 
            resources.ApplyResources(this.gaussianBlurToolStripMenuItem, "gaussianBlurToolStripMenuItem");
            this.gaussianBlurToolStripMenuItem.Name = "gaussianBlurToolStripMenuItem";
            this.gaussianBlurToolStripMenuItem.Click += new System.EventHandler(this.gaussianBlurToolStripMenuItem_Click);
            // 
            // sharpenToolStripMenuItem1
            // 
            resources.ApplyResources(this.sharpenToolStripMenuItem1, "sharpenToolStripMenuItem1");
            this.sharpenToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.erosionToolStripMenuItem,
            this.sharpenToolStripMenuItem,
            this.sharpenMoreToolStripMenuItem,
            this.unsharpMaskToolStripMenuItem});
            this.sharpenToolStripMenuItem1.Name = "sharpenToolStripMenuItem1";
            // 
            // erosionToolStripMenuItem
            // 
            resources.ApplyResources(this.erosionToolStripMenuItem, "erosionToolStripMenuItem");
            this.erosionToolStripMenuItem.Name = "erosionToolStripMenuItem";
            this.erosionToolStripMenuItem.Click += new System.EventHandler(this.erosionToolStripMenuItem_Click);
            // 
            // sharpenToolStripMenuItem
            // 
            resources.ApplyResources(this.sharpenToolStripMenuItem, "sharpenToolStripMenuItem");
            this.sharpenToolStripMenuItem.Name = "sharpenToolStripMenuItem";
            this.sharpenToolStripMenuItem.Click += new System.EventHandler(this.sharpenToolStripMenuItem_Click);
            // 
            // sharpenMoreToolStripMenuItem
            // 
            resources.ApplyResources(this.sharpenMoreToolStripMenuItem, "sharpenMoreToolStripMenuItem");
            this.sharpenMoreToolStripMenuItem.Name = "sharpenMoreToolStripMenuItem";
            this.sharpenMoreToolStripMenuItem.Click += new System.EventHandler(this.sharpenMoreToolStripMenuItem_Click);
            // 
            // unsharpMaskToolStripMenuItem
            // 
            resources.ApplyResources(this.unsharpMaskToolStripMenuItem, "unsharpMaskToolStripMenuItem");
            this.unsharpMaskToolStripMenuItem.Name = "unsharpMaskToolStripMenuItem";
            this.unsharpMaskToolStripMenuItem.Click += new System.EventHandler(this.unsharpMaskToolStripMenuItem_Click);
            // 
            // stylizeToolStripMenuItem
            // 
            resources.ApplyResources(this.stylizeToolStripMenuItem, "stylizeToolStripMenuItem");
            this.stylizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.edgeDetectionToolStripMenuItem});
            this.stylizeToolStripMenuItem.Name = "stylizeToolStripMenuItem";
            // 
            // edgeDetectionToolStripMenuItem
            // 
            resources.ApplyResources(this.edgeDetectionToolStripMenuItem, "edgeDetectionToolStripMenuItem");
            this.edgeDetectionToolStripMenuItem.Name = "edgeDetectionToolStripMenuItem";
            this.edgeDetectionToolStripMenuItem.Click += new System.EventHandler(this.edgeDetectionToolStripMenuItem_Click);
            // 
            // settingsToolStripDropDownButton
            // 
            resources.ApplyResources(this.settingsToolStripDropDownButton, "settingsToolStripDropDownButton");
            this.settingsToolStripDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.settingsToolStripDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.languageToolStripMenuItem});
            this.settingsToolStripDropDownButton.Name = "settingsToolStripDropDownButton";
            // 
            // languageToolStripMenuItem
            // 
            resources.ApplyResources(this.languageToolStripMenuItem, "languageToolStripMenuItem");
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.englishToolStripMenuItem,
            this.russianToolStripMenuItem});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            // 
            // englishToolStripMenuItem
            // 
            resources.ApplyResources(this.englishToolStripMenuItem, "englishToolStripMenuItem");
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            this.englishToolStripMenuItem.Click += new System.EventHandler(this.englishToolStripMenuItem_Click);
            // 
            // russianToolStripMenuItem
            // 
            resources.ApplyResources(this.russianToolStripMenuItem, "russianToolStripMenuItem");
            this.russianToolStripMenuItem.Name = "russianToolStripMenuItem";
            this.russianToolStripMenuItem.Click += new System.EventHandler(this.russianToolStripMenuItem_Click);
            // 
            // pictureBox
            // 
            resources.ApplyResources(this.pictureBox, "pictureBox");
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.TabStop = false;
            this.pictureBox.Click += new System.EventHandler(this.pictureBox_Click);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.topToolStrip);
            this.Name = "MainForm";
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
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.ToolStripDropDownButton filterToolStripDropDownButton;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adjustmentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorBalanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem brightnessContrastToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exposureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thresholdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blackAndWhiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem photoFilterToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton settingsToolStripDropDownButton;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem russianToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blurToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem boxBlurToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gaussianBlurToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sharpenToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem sharpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sharpenMoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sepiaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unsharpMaskToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stylizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem edgeDetectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dilutionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem erosionToolStripMenuItem;
    }
}