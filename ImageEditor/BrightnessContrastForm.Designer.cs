namespace ImageEditor
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
            this.brightnessTrackbar = new System.Windows.Forms.TrackBar();
            this.contrastTrackbar = new System.Windows.Forms.TrackBar();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.brightnessValue = new System.Windows.Forms.TextBox();
            this.contrastValue = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.brightnessTrackbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contrastTrackbar)).BeginInit();
            this.SuspendLayout();
            // 
            // brightnessTrackbar
            // 
            this.brightnessTrackbar.Location = new System.Drawing.Point(72, 58);
            this.brightnessTrackbar.Name = "brightnessTrackbar";
            this.brightnessTrackbar.Size = new System.Drawing.Size(104, 56);
            this.brightnessTrackbar.TabIndex = 0;
            this.brightnessTrackbar.Scroll += new System.EventHandler(this.brightnessTrackbar_Scroll);
            this.brightnessTrackbar.ValueChanged += new System.EventHandler(this.brightnessTrackbar_ValueChanged);
            // 
            // contrastTrackbar
            // 
            this.contrastTrackbar.Location = new System.Drawing.Point(90, 198);
            this.contrastTrackbar.Name = "contrastTrackbar";
            this.contrastTrackbar.Size = new System.Drawing.Size(104, 56);
            this.contrastTrackbar.TabIndex = 1;
            this.contrastTrackbar.Scroll += new System.EventHandler(this.contrastTrackbar_Scroll);
            this.contrastTrackbar.ValueChanged += new System.EventHandler(this.contrastTrackbar_ValueChanged);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(363, 396);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "button1";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(604, 395);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "button2";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // brightnessValue
            // 
            this.brightnessValue.Location = new System.Drawing.Point(336, 58);
            this.brightnessValue.Name = "brightnessValue";
            this.brightnessValue.Size = new System.Drawing.Size(100, 22);
            this.brightnessValue.TabIndex = 4;
            this.brightnessValue.TextChanged += new System.EventHandler(this.brightnessValue_TextChanged);
            // 
            // contrastValue
            // 
            this.contrastValue.Location = new System.Drawing.Point(326, 174);
            this.contrastValue.Name = "contrastValue";
            this.contrastValue.Size = new System.Drawing.Size(100, 22);
            this.contrastValue.TabIndex = 5;
            this.contrastValue.TextChanged += new System.EventHandler(this.contrastValue_TextChanged);
            // 
            // BrightnessContrastForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.contrastValue);
            this.Controls.Add(this.brightnessValue);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.contrastTrackbar);
            this.Controls.Add(this.brightnessTrackbar);
            this.Name = "BrightnessContrastForm";
            this.Text = "BrightnessContrastForm";
            this.Load += new System.EventHandler(this.BrightnessContrastForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.brightnessTrackbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contrastTrackbar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar brightnessTrackbar;
        private System.Windows.Forms.TrackBar contrastTrackbar;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox brightnessValue;
        private System.Windows.Forms.TextBox contrastValue;
    }
}