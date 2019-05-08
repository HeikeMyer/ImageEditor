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
            this.exposureTrackBar.Location = new System.Drawing.Point(25, 60);
            this.exposureTrackBar.Margin = new System.Windows.Forms.Padding(0);
            this.exposureTrackBar.Name = "exposureTrackBar";
            this.exposureTrackBar.Size = new System.Drawing.Size(400, 56);
            this.exposureTrackBar.TabIndex = 0;
            this.exposureTrackBar.Scroll += new System.EventHandler(this.exposureTrackBar_Scroll);
            this.exposureTrackBar.ValueChanged += new System.EventHandler(this.exposureTrackBar_ValueChanged);
            // 
            // gammaTrackBar
            // 
            this.gammaTrackBar.Location = new System.Drawing.Point(25, 161);
            this.gammaTrackBar.Name = "gammaTrackBar";
            this.gammaTrackBar.Size = new System.Drawing.Size(400, 56);
            this.gammaTrackBar.TabIndex = 1;
            this.gammaTrackBar.Scroll += new System.EventHandler(this.gammaTrackBar_Scroll);
            this.gammaTrackBar.ValueChanged += new System.EventHandler(this.gammaTrackBar_ValueChanged);
            // 
            // exposureValue
            // 
            this.exposureValue.Location = new System.Drawing.Point(325, 25);
            this.exposureValue.Name = "exposureValue";
            this.exposureValue.Size = new System.Drawing.Size(100, 22);
            this.exposureValue.TabIndex = 2;
            this.exposureValue.TextChanged += new System.EventHandler(this.exposureValue_TextChanged);
            // 
            // gammaValue
            // 
            this.gammaValue.Location = new System.Drawing.Point(325, 126);
            this.gammaValue.Name = "gammaValue";
            this.gammaValue.Size = new System.Drawing.Size(100, 22);
            this.gammaValue.TabIndex = 3;
            this.gammaValue.TextChanged += new System.EventHandler(this.gammaValue_TextChanged);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(475, 86);
            this.okButton.Margin = new System.Windows.Forms.Padding(0);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 4;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(475, 131);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(0);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // exposureLabel
            // 
            this.exposureLabel.AutoSize = true;
            this.exposureLabel.Location = new System.Drawing.Point(25, 25);
            this.exposureLabel.Margin = new System.Windows.Forms.Padding(0);
            this.exposureLabel.MinimumSize = new System.Drawing.Size(75, 20);
            this.exposureLabel.Name = "exposureLabel";
            this.exposureLabel.Size = new System.Drawing.Size(75, 20);
            this.exposureLabel.TabIndex = 6;
            this.exposureLabel.Text = "Exposure";
            // 
            // gammaLabel
            // 
            this.gammaLabel.AutoSize = true;
            this.gammaLabel.Location = new System.Drawing.Point(25, 126);
            this.gammaLabel.Margin = new System.Windows.Forms.Padding(0);
            this.gammaLabel.MinimumSize = new System.Drawing.Size(75, 20);
            this.gammaLabel.Name = "gammaLabel";
            this.gammaLabel.Size = new System.Drawing.Size(75, 20);
            this.gammaLabel.TabIndex = 7;
            this.gammaLabel.Text = "Gamma";
            // 
            // ExposureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 243);
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
            this.Text = "Exposure";
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