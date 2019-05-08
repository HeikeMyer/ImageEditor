namespace ImageEditor.Forms
{
    partial class ExposureForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExposureForm));
            this.exposureTrackBar = new System.Windows.Forms.TrackBar();
            this.gammaTrackBar = new System.Windows.Forms.TrackBar();
            this.exposureValue = new System.Windows.Forms.TextBox();
            this.gammaValue = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.exposureLabel = new System.Windows.Forms.Label();
            this.gammaLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.exposureTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gammaTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // exposureTrackBar
            // 
            resources.ApplyResources(this.exposureTrackBar, "exposureTrackBar");
            this.exposureTrackBar.Name = "exposureTrackBar";
            this.exposureTrackBar.Scroll += new System.EventHandler(this.exposureTrackBar_Scroll);
            this.exposureTrackBar.ValueChanged += new System.EventHandler(this.exposureTrackBar_ValueChanged);
            // 
            // gammaTrackBar
            // 
            resources.ApplyResources(this.gammaTrackBar, "gammaTrackBar");
            this.gammaTrackBar.Name = "gammaTrackBar";
            this.gammaTrackBar.Scroll += new System.EventHandler(this.gammaTrackBar_Scroll);
            this.gammaTrackBar.ValueChanged += new System.EventHandler(this.gammaTrackBar_ValueChanged);
            // 
            // exposureValue
            // 
            resources.ApplyResources(this.exposureValue, "exposureValue");
            this.exposureValue.Name = "exposureValue";
            this.exposureValue.TextChanged += new System.EventHandler(this.exposureValue_TextChanged);
            // 
            // gammaValue
            // 
            resources.ApplyResources(this.gammaValue, "gammaValue");
            this.gammaValue.Name = "gammaValue";
            this.gammaValue.TextChanged += new System.EventHandler(this.gammaValue_TextChanged);
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
            // exposureLabel
            // 
            resources.ApplyResources(this.exposureLabel, "exposureLabel");
            this.exposureLabel.Name = "exposureLabel";
            // 
            // gammaLabel
            // 
            resources.ApplyResources(this.gammaLabel, "gammaLabel");
            this.gammaLabel.Name = "gammaLabel";
            // 
            // ExposureForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gammaLabel);
            this.Controls.Add(this.exposureLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.gammaValue);
            this.Controls.Add(this.exposureValue);
            this.Controls.Add(this.gammaTrackBar);
            this.Controls.Add(this.exposureTrackBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ExposureForm";
            this.Load += new System.EventHandler(this.ExposureForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.exposureTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gammaTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar exposureTrackBar;
        private System.Windows.Forms.TrackBar gammaTrackBar;
        private System.Windows.Forms.TextBox exposureValue;
        private System.Windows.Forms.TextBox gammaValue;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label exposureLabel;
        private System.Windows.Forms.Label gammaLabel;
    }
}