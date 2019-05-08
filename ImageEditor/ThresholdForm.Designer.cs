namespace ImageEditor
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
            this.okButton.Location = new System.Drawing.Point(475, 30);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 25);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(475, 70);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 25);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // thresholdValue
            // 
            this.thresholdValue.Location = new System.Drawing.Point(325, 25);
            this.thresholdValue.Name = "thresholdValue";
            this.thresholdValue.Size = new System.Drawing.Size(100, 22);
            this.thresholdValue.TabIndex = 2;
            this.thresholdValue.TextChanged += new System.EventHandler(this.thresholdValue_TextChanged);
            // 
            // thresholdTrackBar
            // 
            this.thresholdTrackBar.Location = new System.Drawing.Point(25, 60);
            this.thresholdTrackBar.Margin = new System.Windows.Forms.Padding(0);
            this.thresholdTrackBar.Name = "thresholdTrackBar";
            this.thresholdTrackBar.Size = new System.Drawing.Size(400, 56);
            this.thresholdTrackBar.TabIndex = 3;
            this.thresholdTrackBar.Scroll += new System.EventHandler(this.thresholdTrackBar_Scroll);
            this.thresholdTrackBar.ValueChanged += new System.EventHandler(this.thresholdTrackBar_ValueChanged);
            // 
            // labelThresholdLevel
            // 
            this.labelThresholdLevel.AutoSize = true;
            this.labelThresholdLevel.Location = new System.Drawing.Point(25, 25);
            this.labelThresholdLevel.Margin = new System.Windows.Forms.Padding(0);
            this.labelThresholdLevel.MinimumSize = new System.Drawing.Size(75, 20);
            this.labelThresholdLevel.Name = "labelThresholdLevel";
            this.labelThresholdLevel.Size = new System.Drawing.Size(110, 20);
            this.labelThresholdLevel.TabIndex = 4;
            this.labelThresholdLevel.Text = "Threshold Level";
            // 
            // ThresholdForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 121);
            this.Controls.Add(this.labelThresholdLevel);
            this.Controls.Add(this.thresholdTrackBar);
            this.Controls.Add(this.thresholdValue);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ThresholdForm";
            this.Text = "Threshold Level";
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