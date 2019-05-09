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
            this.cancelButton = new System.Windows.Forms.Button();
            this.brightnessValue = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.contrastValue = new System.Windows.Forms.TextBox();
            this.contrastTrackBar = new System.Windows.Forms.TrackBar();
            this.brightnessTrackBar = new System.Windows.Forms.TrackBar();
            this.contrastLabel = new System.Windows.Forms.Label();
            this.brightnessLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.contrastTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brightnessTrackBar)).BeginInit();
            this.SuspendLayout();
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
            // okButton
            // 
            resources.ApplyResources(this.okButton, "okButton");
            this.okButton.Name = "okButton";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // contrastValue
            // 
            resources.ApplyResources(this.contrastValue, "contrastValue");
            this.contrastValue.Name = "contrastValue";
            this.contrastValue.TextChanged += new System.EventHandler(this.contrastValue_TextChanged);
            // 
            // contrastTrackBar
            // 
            resources.ApplyResources(this.contrastTrackBar, "contrastTrackBar");
            this.contrastTrackBar.Name = "contrastTrackBar";
            this.contrastTrackBar.Scroll += new System.EventHandler(this.contrastTrackbar_Scroll);
            this.contrastTrackBar.ValueChanged += new System.EventHandler(this.contrastTrackbar_ValueChanged);
            // 
            // brightnessTrackBar
            // 
            resources.ApplyResources(this.brightnessTrackBar, "brightnessTrackBar");
            this.brightnessTrackBar.Name = "brightnessTrackBar";
            this.brightnessTrackBar.Scroll += new System.EventHandler(this.brightnessTrackbar_Scroll);
            this.brightnessTrackBar.ValueChanged += new System.EventHandler(this.brightnessTrackbar_ValueChanged);
            // 
            // contrastLabel
            // 
            resources.ApplyResources(this.contrastLabel, "contrastLabel");
            this.contrastLabel.Name = "contrastLabel";
            // 
            // brightnessLabel
            // 
            resources.ApplyResources(this.brightnessLabel, "brightnessLabel");
            this.brightnessLabel.Name = "brightnessLabel";
            // 
            // BrightnessContrastForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.brightnessLabel);
            this.Controls.Add(this.contrastLabel);
            this.Controls.Add(this.brightnessTrackBar);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.contrastTrackBar);
            this.Controls.Add(this.brightnessValue);
            this.Controls.Add(this.contrastValue);
            this.Controls.Add(this.okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "BrightnessContrastForm";
            this.Load += new System.EventHandler(this.BrightnessContrastForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.contrastTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brightnessTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox brightnessValue;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.TextBox contrastValue;
        private System.Windows.Forms.TrackBar contrastTrackBar;
        private System.Windows.Forms.TrackBar brightnessTrackBar;
        private System.Windows.Forms.Label contrastLabel;
        private System.Windows.Forms.Label brightnessLabel;
    }
}