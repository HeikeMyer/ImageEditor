namespace ImageEditor.Forms
{
    partial class BrightnessContrastForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BrightnessContrastForm));
            this.brightnessTrackBar = new System.Windows.Forms.TrackBar();
            this.contrastTrackBar = new System.Windows.Forms.TrackBar();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.brightnessValue = new System.Windows.Forms.TextBox();
            this.contrastValue = new System.Windows.Forms.TextBox();
            this.brightnessLabel = new System.Windows.Forms.Label();
            this.contrastLabel = new System.Windows.Forms.Label();
            this.panel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.brightnessTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contrastTrackBar)).BeginInit();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // brightnessTrackBar
            // 
            resources.ApplyResources(this.brightnessTrackBar, "brightnessTrackBar");
            this.brightnessTrackBar.Name = "brightnessTrackBar";
            this.brightnessTrackBar.Scroll += new System.EventHandler(this.brightnessTrackbar_Scroll);
            this.brightnessTrackBar.ValueChanged += new System.EventHandler(this.brightnessTrackbar_ValueChanged);
            // 
            // contrastTrackBar
            // 
            resources.ApplyResources(this.contrastTrackBar, "contrastTrackBar");
            this.contrastTrackBar.Name = "contrastTrackBar";
            this.contrastTrackBar.Scroll += new System.EventHandler(this.contrastTrackbar_Scroll);
            this.contrastTrackBar.ValueChanged += new System.EventHandler(this.contrastTrackbar_ValueChanged);
            // 
            // okButton
            // 
            resources.ApplyResources(this.okButton, "okButton");
            this.okButton.Name = "okButton";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // brightnessValue
            // 
            resources.ApplyResources(this.brightnessValue, "brightnessValue");
            this.brightnessValue.Name = "brightnessValue";
            this.brightnessValue.TextChanged += new System.EventHandler(this.brightnessValue_TextChanged);
            // 
            // contrastValue
            // 
            resources.ApplyResources(this.contrastValue, "contrastValue");
            this.contrastValue.Name = "contrastValue";
            this.contrastValue.TextChanged += new System.EventHandler(this.contrastValue_TextChanged);
            // 
            // brightnessLabel
            // 
            resources.ApplyResources(this.brightnessLabel, "brightnessLabel");
            this.brightnessLabel.Name = "brightnessLabel";
            this.brightnessLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // contrastLabel
            // 
            resources.ApplyResources(this.contrastLabel, "contrastLabel");
            this.contrastLabel.Name = "contrastLabel";
            // 
            // panel
            // 
            resources.ApplyResources(this.panel, "panel");
            this.panel.Controls.Add(this.brightnessLabel);
            this.panel.Controls.Add(this.contrastLabel);
            this.panel.Controls.Add(this.brightnessTrackBar);
            this.panel.Controls.Add(this.contrastTrackBar);
            this.panel.Controls.Add(this.contrastValue);
            this.panel.Controls.Add(this.okButton);
            this.panel.Controls.Add(this.brightnessValue);
            this.panel.Controls.Add(this.cancelButton);
            this.panel.Name = "panel";
            this.panel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // BrightnessContrastForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "BrightnessContrastForm";
            this.Load += new System.EventHandler(this.BrightnessContrastForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.brightnessTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contrastTrackBar)).EndInit();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TrackBar brightnessTrackBar;
        private System.Windows.Forms.TrackBar contrastTrackBar;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox brightnessValue;
        private System.Windows.Forms.TextBox contrastValue;
        private System.Windows.Forms.Label brightnessLabel;
        private System.Windows.Forms.Label contrastLabel;
        private System.Windows.Forms.Panel panel;
    }
}