namespace ImageEditor
{
    partial class ColorBalanceForm
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
            this.redValue = new System.Windows.Forms.TextBox();
            this.greenValue = new System.Windows.Forms.TextBox();
            this.blueValue = new System.Windows.Forms.TextBox();
            this.redTrackBar = new System.Windows.Forms.TrackBar();
            this.greenTrackBar = new System.Windows.Forms.TrackBar();
            this.blueTrackBar = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.redTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(510, 291);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "button1";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(519, 336);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "button2";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // redValue
            // 
            this.redValue.Location = new System.Drawing.Point(415, 83);
            this.redValue.Name = "redValue";
            this.redValue.Size = new System.Drawing.Size(100, 22);
            this.redValue.TabIndex = 2;
            this.redValue.TextChanged += new System.EventHandler(this.redValue_TextChanged);
            // 
            // greenValue
            // 
            this.greenValue.Location = new System.Drawing.Point(432, 171);
            this.greenValue.Name = "greenValue";
            this.greenValue.Size = new System.Drawing.Size(100, 22);
            this.greenValue.TabIndex = 3;
            this.greenValue.TextChanged += new System.EventHandler(this.greenValue_TextChanged);
            // 
            // blueValue
            // 
            this.blueValue.Location = new System.Drawing.Point(432, 229);
            this.blueValue.Name = "blueValue";
            this.blueValue.Size = new System.Drawing.Size(100, 22);
            this.blueValue.TabIndex = 4;
            this.blueValue.TextChanged += new System.EventHandler(this.blueValue_TextChanged);
            // 
            // redTrackBar
            // 
            this.redTrackBar.Location = new System.Drawing.Point(141, 83);
            this.redTrackBar.Name = "redTrackBar";
            this.redTrackBar.Size = new System.Drawing.Size(104, 56);
            this.redTrackBar.TabIndex = 5;
            this.redTrackBar.Scroll += new System.EventHandler(this.redTrackBar_Scroll);
            this.redTrackBar.ValueChanged += new System.EventHandler(this.redTrackBar_ValueChanged);
            // 
            // greenTrackBar
            // 
            this.greenTrackBar.Location = new System.Drawing.Point(165, 136);
            this.greenTrackBar.Name = "greenTrackBar";
            this.greenTrackBar.Size = new System.Drawing.Size(104, 56);
            this.greenTrackBar.TabIndex = 6;
            this.greenTrackBar.Scroll += new System.EventHandler(this.greenTrackBar_Scroll);
            this.greenTrackBar.ValueChanged += new System.EventHandler(this.greenTrackBar_ValueChanged);
            // 
            // blueTrackBar
            // 
            this.blueTrackBar.Location = new System.Drawing.Point(165, 208);
            this.blueTrackBar.Name = "blueTrackBar";
            this.blueTrackBar.Size = new System.Drawing.Size(104, 56);
            this.blueTrackBar.TabIndex = 7;
            this.blueTrackBar.Scroll += new System.EventHandler(this.blueTrackBar_Scroll);
            this.blueTrackBar.ValueChanged += new System.EventHandler(this.blueTrackBar_ValueChanged);
            // 
            // ColorBalanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.blueTrackBar);
            this.Controls.Add(this.greenTrackBar);
            this.Controls.Add(this.redTrackBar);
            this.Controls.Add(this.blueValue);
            this.Controls.Add(this.greenValue);
            this.Controls.Add(this.redValue);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Name = "ColorBalanceForm";
            this.Text = "ColorBalanceForm";
            this.Load += new System.EventHandler(this.ColorBalanceForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.redTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox redValue;
        private System.Windows.Forms.TextBox greenValue;
        private System.Windows.Forms.TextBox blueValue;
        private System.Windows.Forms.TrackBar redTrackBar;
        private System.Windows.Forms.TrackBar greenTrackBar;
        private System.Windows.Forms.TrackBar blueTrackBar;
    }
}