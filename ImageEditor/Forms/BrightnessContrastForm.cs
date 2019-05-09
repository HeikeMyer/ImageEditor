using System;
using System.Drawing;
using System.Windows.Forms;
using ImageProcessing;
using ImageEditor.Constants;
using System.Configuration;
using System.Resources;
using ImageEditor.Interfaces;

namespace ImageEditor.Forms
{
    public partial class BrightnessContrastForm : Form, IImageProcessingDialogForm
    {
        public event ImageProcessingEventHandler ProcessingCompleted;


        protected virtual void OnProcessingCompleted(Bitmap processedImage)
        {
            ProcessingCompleted?.Invoke(this, new ImageProcessingEventArgs() { Image = processedImage });
        }


        public event ImageProcessingEventHandler ProcessingApproved;


        protected virtual void OnProcessingApproved()
        {
            ProcessingApproved?.Invoke(this, new ImageProcessingEventArgs());
        }


        public event ImageProcessingEventHandler ProcessingCanceled;


        protected virtual void OnProcessingCanceled()
        {
            ProcessingCanceled?.Invoke(this, new ImageProcessingEventArgs());
        }


        private ImageProcessingApi brightnessContrast;
        private Bitmap input;

        public void SetInputImage(object sender, ImageProcessingEventArgs e)
        {
            input = e.Image;
        }


        public BrightnessContrastForm()
        {
            InitializeComponent();

            brightnessTrackBar.Minimum = ControlConstants.MinBrightness;
            brightnessTrackBar.Maximum = ControlConstants.MaxBrightness;

            contrastTrackBar.Minimum = ControlConstants.MinBrightness;
            contrastTrackBar.Maximum = ControlConstants.MaxBrightness;

        }

        private void okButton_Click(object sender, EventArgs e)
        {
            OnProcessingApproved();
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            OnProcessingCanceled();
            Close();
        }

        private void BrightnessContrastForm_Load(object sender, EventArgs e)
        {
            brightnessContrast = new ImageProcessingApi();

            brightnessTrackBar.Value = ControlConstants.DefaultBrightness;
            brightnessValue.Text = ControlConstants.DefaultBrightness.ToString();

            contrastTrackBar.Value = ControlConstants.DefaultContrast;
            contrastValue.Text = ControlConstants.DefaultContrast.ToString();
            
            ReloadTextFormExtension.ReloadText(this, GetType());
            //ReloadTextFormExtension.ReloadText(this, GetType(), ReloadControlText, cultureCode);
        }

        private void brightnessTrackbar_Scroll(object sender, EventArgs e)
        {
            Synchronization.SynchronizeTextBox(brightnessValue, brightnessTrackBar);
        }

        private void contrastTrackbar_Scroll(object sender, EventArgs e)
        {
            Synchronization.SynchronizeTextBox(contrastValue, contrastTrackBar);
        }

        private void brightnessTrackbar_ValueChanged(object sender, EventArgs e)
        {
            Bitmap preview = new Bitmap(input);
            brightnessContrast.BrightnessContrast(preview, brightnessTrackBar.Value, contrastTrackBar.Value);
            OnProcessingCompleted(preview);
        }

        private void contrastTrackbar_ValueChanged(object sender, EventArgs e)
        {
            Bitmap preview = new Bitmap(input);
            brightnessContrast.BrightnessContrast(preview, brightnessTrackBar.Value, contrastTrackBar.Value);
            OnProcessingCompleted(preview);

        }

        private void brightnessValue_TextChanged(object sender, EventArgs e)
        {
            Synchronization.SynchronizeTrackBar(brightnessTrackBar, brightnessValue);
        }

        private void contrastValue_TextChanged(object sender, EventArgs e)
        {
            Synchronization.SynchronizeTrackBar(contrastTrackBar, contrastValue);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public void ReloadControlText(ResourceManager resourceManager)
        {
            brightnessLabel.Text = resourceManager.GetString(nameof(brightnessLabel) + ControlConstants.TextPropertyName);
            contrastLabel.Text = resourceManager.GetString(nameof(contrastLabel) + ControlConstants.TextPropertyName);
            cancelButton.Text = resourceManager.GetString(nameof(cancelButton) + ControlConstants.TextPropertyName);
        }
    }
}
