namespace ImageEditor.Forms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColorBalanceForm));
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
            // redValue
            // 
            resources.ApplyResources(this.redValue, "redValue");
            this.redValue.Name = "redValue";
            this.redValue.TextChanged += new System.EventHandler(this.redValue_TextChanged);
            // 
            // greenValue
            // 
            resources.ApplyResources(this.greenValue, "greenValue");
            this.greenValue.Name = "greenValue";
            this.greenValue.TextChanged += new System.EventHandler(this.greenValue_TextChanged);
            // 
            // blueValue
            // 
            resources.ApplyResources(this.blueValue, "blueValue");
            this.blueValue.Name = "blueValue";
            this.blueValue.TextChanged += new System.EventHandler(this.blueValue_TextChanged);
            // 
            // redTrackBar
            // 
            resources.ApplyResources(this.redTrackBar, "redTrackBar");
            this.redTrackBar.Name = "redTrackBar";
            this.redTrackBar.Scroll += new System.EventHandler(this.redTrackBar_Scroll);
            this.redTrackBar.ValueChanged += new System.EventHandler(this.redTrackBar_ValueChanged);
            // 
            // greenTrackBar
            // 
            resources.ApplyResources(this.greenTrackBar, "greenTrackBar");
            this.greenTrackBar.Name = "greenTrackBar";
            this.greenTrackBar.Scroll += new System.EventHandler(this.greenTrackBar_Scroll);
            this.greenTrackBar.ValueChanged += new System.EventHandler(this.greenTrackBar_ValueChanged);
            // 
            // blueTrackBar
            // 
            resources.ApplyResources(this.blueTrackBar, "blueTrackBar");
            this.blueTrackBar.Name = "blueTrackBar";
            this.blueTrackBar.Scroll += new System.EventHandler(this.blueTrackBar_Scroll);
            this.blueTrackBar.ValueChanged += new System.EventHandler(this.blueTrackBar_ValueChanged);
            // 
            // cyanLabel
            // 
            resources.ApplyResources(this.cyanLabel, "cyanLabel");
            this.cyanLabel.Name = "cyanLabel";
            // 
            // magentaLabel
            // 
            resources.ApplyResources(this.magentaLabel, "magentaLabel");
            this.magentaLabel.Name = "magentaLabel";
            // 
            // yellowLabel
            // 
            resources.ApplyResources(this.yellowLabel, "yellowLabel");
            this.yellowLabel.Name = "yellowLabel";
            // 
            // greenLabel
            // 
            resources.ApplyResources(this.greenLabel, "greenLabel");
            this.greenLabel.Name = "greenLabel";
            // 
            // redLabel
            // 
            resources.ApplyResources(this.redLabel, "redLabel");
            this.redLabel.Name = "redLabel";
            // 
            // blueLabel
            // 
            resources.ApplyResources(this.blueLabel, "blueLabel");
            this.blueLabel.Name = "blueLabel";
            // 
            // ColorBalanceForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ColorBalanceForm";
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