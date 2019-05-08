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
            this.brightnessTrackBar.Location = new System.Drawing.Point(25, 60);
            this.brightnessTrackBar.Margin = new System.Windows.Forms.Padding(0);
            this.brightnessTrackBar.Name = "brightnessTrackBar";
            this.brightnessTrackBar.Size = new System.Drawing.Size(400, 56);
            this.brightnessTrackBar.TabIndex = 0;
            this.brightnessTrackBar.Scroll += new System.EventHandler(this.brightnessTrackbar_Scroll);
            this.brightnessTrackBar.ValueChanged += new System.EventHandler(this.brightnessTrackbar_ValueChanged);
            // 
            // contrastTrackBar
            // 
            this.contrastTrackBar.Location = new System.Drawing.Point(25, 161);
            this.contrastTrackBar.Name = "contrastTrackBar";
            this.contrastTrackBar.Size = new System.Drawing.Size(400, 56);
            this.contrastTrackBar.TabIndex = 1;
            this.contrastTrackBar.Scroll += new System.EventHandler(this.contrastTrackbar_Scroll);
            this.contrastTrackBar.ValueChanged += new System.EventHandler(this.contrastTrackbar_ValueChanged);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(475, 86);
            this.okButton.MinimumSize = new System.Drawing.Size(75, 25);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 25);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(475, 131);
            this.cancelButton.MinimumSize = new System.Drawing.Size(75, 25);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 25);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // brightnessValue
            // 
            this.brightnessValue.Location = new System.Drawing.Point(325, 25);
            this.brightnessValue.Margin = new System.Windows.Forms.Padding(0);
            this.brightnessValue.Name = "brightnessValue";
            this.brightnessValue.Size = new System.Drawing.Size(100, 22);
            this.brightnessValue.TabIndex = 4;
            this.brightnessValue.TextChanged += new System.EventHandler(this.brightnessValue_TextChanged);
            // 
            // contrastValue
            // 
            this.contrastValue.Location = new System.Drawing.Point(325, 126);
            this.contrastValue.Name = "contrastValue";
            this.contrastValue.Size = new System.Drawing.Size(100, 22);
            this.contrastValue.TabIndex = 5;
            this.contrastValue.TextChanged += new System.EventHandler(this.contrastValue_TextChanged);
            // 
            // brightnessLabel
            // 
            this.brightnessLabel.AutoSize = true;
            this.brightnessLabel.Location = new System.Drawing.Point(25, 25);
            this.brightnessLabel.Margin = new System.Windows.Forms.Padding(0);
            this.brightnessLabel.MinimumSize = new System.Drawing.Size(50, 20);
            this.brightnessLabel.Name = "brightnessLabel";
            this.brightnessLabel.Size = new System.Drawing.Size(75, 20);
            this.brightnessLabel.TabIndex = 6;
            this.brightnessLabel.Text = "Brightness";
            this.brightnessLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // contrastLabel
            // 
            this.contrastLabel.AutoSize = true;
            this.contrastLabel.Location = new System.Drawing.Point(25, 126);
            this.contrastLabel.Margin = new System.Windows.Forms.Padding(0);
            this.contrastLabel.MinimumSize = new System.Drawing.Size(50, 20);
            this.contrastLabel.Name = "contrastLabel";
            this.contrastLabel.Size = new System.Drawing.Size(61, 20);
            this.contrastLabel.TabIndex = 7;
            this.contrastLabel.Text = "Contrast";
            // 
            // panel
            // 
            this.panel.Controls.Add(this.brightnessLabel);
            this.panel.Controls.Add(this.contrastLabel);
            this.panel.Controls.Add(this.brightnessTrackBar);
            this.panel.Controls.Add(this.contrastTrackBar);
            this.panel.Controls.Add(this.contrastValue);
            this.panel.Controls.Add(this.okButton);
            this.panel.Controls.Add(this.brightnessValue);
            this.panel.Controls.Add(this.cancelButton);
            this.panel.Location = new System.Drawing.Point(0, 1);
            this.panel.Margin = new System.Windows.Forms.Padding(0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(600, 242);
            this.panel.TabIndex = 8;
            this.panel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // BrightnessContrastForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 243);
            this.Controls.Add(this.panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "BrightnessContrastForm";
            this.Text = "Brightness/Contrast";
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