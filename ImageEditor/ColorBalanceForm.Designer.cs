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
            this.cyanLabel = new System.Windows.Forms.Label();
            this.magentaLabel = new System.Windows.Forms.Label();
            this.yellowLabel = new System.Windows.Forms.Label();
            this.greenLabel = new System.Windows.Forms.Label();
            this.redLabel = new System.Windows.Forms.Label();
            this.blueLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.redTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(625, 120);
            this.okButton.Margin = new System.Windows.Forms.Padding(0);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(625, 170);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(0);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // redValue
            // 
            this.redValue.Location = new System.Drawing.Point(125, 25);
            this.redValue.Margin = new System.Windows.Forms.Padding(0);
            this.redValue.Name = "redValue";
            this.redValue.Size = new System.Drawing.Size(100, 22);
            this.redValue.TabIndex = 2;
            this.redValue.TextChanged += new System.EventHandler(this.redValue_TextChanged);
            // 
            // greenValue
            // 
            this.greenValue.Location = new System.Drawing.Point(250, 25);
            this.greenValue.Margin = new System.Windows.Forms.Padding(0);
            this.greenValue.Name = "greenValue";
            this.greenValue.Size = new System.Drawing.Size(100, 22);
            this.greenValue.TabIndex = 3;
            this.greenValue.TextChanged += new System.EventHandler(this.greenValue_TextChanged);
            // 
            // blueValue
            // 
            this.blueValue.Location = new System.Drawing.Point(375, 25);
            this.blueValue.Margin = new System.Windows.Forms.Padding(0);
            this.blueValue.Name = "blueValue";
            this.blueValue.Size = new System.Drawing.Size(100, 22);
            this.blueValue.TabIndex = 4;
            this.blueValue.TextChanged += new System.EventHandler(this.blueValue_TextChanged);
            // 
            // redTrackBar
            // 
            this.redTrackBar.Location = new System.Drawing.Point(100, 72);
            this.redTrackBar.Margin = new System.Windows.Forms.Padding(0);
            this.redTrackBar.Name = "redTrackBar";
            this.redTrackBar.Size = new System.Drawing.Size(400, 56);
            this.redTrackBar.TabIndex = 5;
            this.redTrackBar.Scroll += new System.EventHandler(this.redTrackBar_Scroll);
            this.redTrackBar.ValueChanged += new System.EventHandler(this.redTrackBar_ValueChanged);
            // 
            // greenTrackBar
            // 
            this.greenTrackBar.Location = new System.Drawing.Point(100, 153);
            this.greenTrackBar.Margin = new System.Windows.Forms.Padding(0);
            this.greenTrackBar.Name = "greenTrackBar";
            this.greenTrackBar.Size = new System.Drawing.Size(400, 56);
            this.greenTrackBar.TabIndex = 6;
            this.greenTrackBar.Scroll += new System.EventHandler(this.greenTrackBar_Scroll);
            this.greenTrackBar.ValueChanged += new System.EventHandler(this.greenTrackBar_ValueChanged);
            // 
            // blueTrackBar
            // 
            this.blueTrackBar.Location = new System.Drawing.Point(100, 234);
            this.blueTrackBar.Margin = new System.Windows.Forms.Padding(0);
            this.blueTrackBar.Name = "blueTrackBar";
            this.blueTrackBar.Size = new System.Drawing.Size(400, 56);
            this.blueTrackBar.TabIndex = 7;
            this.blueTrackBar.Scroll += new System.EventHandler(this.blueTrackBar_Scroll);
            this.blueTrackBar.ValueChanged += new System.EventHandler(this.blueTrackBar_ValueChanged);
            // 
            // label1
            // 
            this.cyanLabel.AutoSize = true;
            this.cyanLabel.Location = new System.Drawing.Point(25, 72);
            this.cyanLabel.Margin = new System.Windows.Forms.Padding(0);
            this.cyanLabel.MinimumSize = new System.Drawing.Size(75, 20);
            this.cyanLabel.Name = "label1";
            this.cyanLabel.Size = new System.Drawing.Size(75, 20);
            this.cyanLabel.TabIndex = 8;
            this.cyanLabel.Text = "Cyan";
            this.cyanLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.magentaLabel.AutoSize = true;
            this.magentaLabel.Location = new System.Drawing.Point(25, 153);
            this.magentaLabel.Margin = new System.Windows.Forms.Padding(0);
            this.magentaLabel.MinimumSize = new System.Drawing.Size(75, 20);
            this.magentaLabel.Name = "label2";
            this.magentaLabel.Size = new System.Drawing.Size(75, 20);
            this.magentaLabel.TabIndex = 9;
            this.magentaLabel.Text = "Magenta";
            // 
            // label3
            // 
            this.yellowLabel.AutoSize = true;
            this.yellowLabel.Location = new System.Drawing.Point(25, 234);
            this.yellowLabel.Margin = new System.Windows.Forms.Padding(0);
            this.yellowLabel.MinimumSize = new System.Drawing.Size(75, 20);
            this.yellowLabel.Name = "label3";
            this.yellowLabel.Size = new System.Drawing.Size(75, 20);
            this.yellowLabel.TabIndex = 10;
            this.yellowLabel.Text = "Yellow";
            // 
            // label4
            // 
            this.greenLabel.AutoSize = true;
            this.greenLabel.Location = new System.Drawing.Point(525, 153);
            this.greenLabel.Margin = new System.Windows.Forms.Padding(0);
            this.greenLabel.MinimumSize = new System.Drawing.Size(75, 20);
            this.greenLabel.Name = "label4";
            this.greenLabel.Size = new System.Drawing.Size(75, 20);
            this.greenLabel.TabIndex = 11;
            this.greenLabel.Text = "Green";
            this.greenLabel.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.redLabel.AutoSize = true;
            this.redLabel.Location = new System.Drawing.Point(525, 72);
            this.redLabel.Margin = new System.Windows.Forms.Padding(0);
            this.redLabel.MinimumSize = new System.Drawing.Size(75, 20);
            this.redLabel.Name = "label5";
            this.redLabel.Size = new System.Drawing.Size(75, 20);
            this.redLabel.TabIndex = 12;
            this.redLabel.Text = "Red";
            // 
            // label6
            // 
            this.blueLabel.AutoSize = true;
            this.blueLabel.Location = new System.Drawing.Point(525, 234);
            this.blueLabel.Margin = new System.Windows.Forms.Padding(0);
            this.blueLabel.MinimumSize = new System.Drawing.Size(75, 20);
            this.blueLabel.Name = "label6";
            this.blueLabel.Size = new System.Drawing.Size(75, 20);
            this.blueLabel.TabIndex = 13;
            this.blueLabel.Text = "Blue";
            // 
            // ColorBalanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 293);
            this.Controls.Add(this.blueLabel);
            this.Controls.Add(this.redLabel);
            this.Controls.Add(this.greenLabel);
            this.Controls.Add(this.yellowLabel);
            this.Controls.Add(this.magentaLabel);
            this.Controls.Add(this.cyanLabel);
            this.Controls.Add(this.blueTrackBar);
            this.Controls.Add(this.greenTrackBar);
            this.Controls.Add(this.redTrackBar);
            this.Controls.Add(this.blueValue);
            this.Controls.Add(this.greenValue);
            this.Controls.Add(this.redValue);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Name = "ColorBalanceForm";
            this.Text = "Color Balance";
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
        private System.Windows.Forms.Label cyanLabel;
        private System.Windows.Forms.Label magentaLabel;
        private System.Windows.Forms.Label yellowLabel;
        private System.Windows.Forms.Label greenLabel;
        private System.Windows.Forms.Label redLabel;
        private System.Windows.Forms.Label blueLabel;
    }
}