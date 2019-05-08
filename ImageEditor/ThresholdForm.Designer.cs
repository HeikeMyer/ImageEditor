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
            ((System.ComponentModel.ISupportInitialize)(this.thresholdTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(611, 149);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "button1";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(621, 225);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "button2";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // thresholdValue
            // 
            this.thresholdValue.Location = new System.Drawing.Point(379, 193);
            this.thresholdValue.Name = "thresholdValue";
            this.thresholdValue.Size = new System.Drawing.Size(100, 22);
            this.thresholdValue.TabIndex = 2;
            this.thresholdValue.TextChanged += new System.EventHandler(this.thresholdValue_TextChanged);
            // 
            // thresholdTrackBar
            // 
            this.thresholdTrackBar.Location = new System.Drawing.Point(102, 177);
            this.thresholdTrackBar.Name = "thresholdTrackBar";
            this.thresholdTrackBar.Size = new System.Drawing.Size(104, 56);
            this.thresholdTrackBar.TabIndex = 3;
            this.thresholdTrackBar.Scroll += new System.EventHandler(this.thresholdTrackBar_Scroll);
            this.thresholdTrackBar.ValueChanged += new System.EventHandler(this.thresholdTrackBar_ValueChanged);
            // 
            // ThresholdForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.thresholdTrackBar);
            this.Controls.Add(this.thresholdValue);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Name = "ThresholdForm";
            this.Text = "ThresholdForm";
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
    }
}