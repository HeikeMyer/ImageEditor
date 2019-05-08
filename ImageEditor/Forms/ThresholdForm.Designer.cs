namespace ImageEditor.Forms
{
    partial class ThresholdForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThresholdForm));
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.thresholdValue = new System.Windows.Forms.TextBox();
            this.thresholdTrackBar = new System.Windows.Forms.TrackBar();
            this.labelThresholdLevel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.thresholdTrackBar)).BeginInit();
            this.SuspendLayout();
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
            // thresholdValue
            // 
            resources.ApplyResources(this.thresholdValue, "thresholdValue");
            this.thresholdValue.Name = "thresholdValue";
            this.thresholdValue.TextChanged += new System.EventHandler(this.thresholdValue_TextChanged);
            // 
            // thresholdTrackBar
            // 
            resources.ApplyResources(this.thresholdTrackBar, "thresholdTrackBar");
            this.thresholdTrackBar.Name = "thresholdTrackBar";
            this.thresholdTrackBar.Scroll += new System.EventHandler(this.thresholdTrackBar_Scroll);
            this.thresholdTrackBar.ValueChanged += new System.EventHandler(this.thresholdTrackBar_ValueChanged);
            // 
            // labelThresholdLevel
            // 
            resources.ApplyResources(this.labelThresholdLevel, "labelThresholdLevel");
            this.labelThresholdLevel.Name = "labelThresholdLevel";
            // 
            // ThresholdForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelThresholdLevel);
            this.Controls.Add(this.thresholdTrackBar);
            this.Controls.Add(this.thresholdValue);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ThresholdForm";
            this.Load += new System.EventHandler(this.ThresholdForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.thresholdTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox thresholdValue;
        private System.Windows.Forms.TrackBar thresholdTrackBar;
        private System.Windows.Forms.Label labelThresholdLevel;
    }
}