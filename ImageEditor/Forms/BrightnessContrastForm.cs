using System;
using System.Drawing;
using System.Windows.Forms;
using ImageProcessing;
using ImageEditor.Constants;
using ImageEditor.Interfaces;

namespace ImageEditor.Forms
{
    public partial class BrightnessContrastForm : Form, IImageProcessingDialogForm
    {
        private Bitmap InputImage { get; set; }

        private ImageProcessingApi ImageProcessingApi { get; set; }

        public void InitializeTrackbars()
        {
            brightnessTrackBar.Minimum = ControlConstants.MinBrightness;
            brightnessTrackBar.Maximum = ControlConstants.MaxBrightness;

            contrastTrackBar.Minimum = ControlConstants.MinBrightness;
            contrastTrackBar.Maximum = ControlConstants.MaxBrightness;
        }

        public BrightnessContrastForm()
        {
            InitializeComponent();
            InitializeTrackbars();
        }

        public void ReloadTrackbars()
        {
            brightnessTrackBar.Value = ControlConstants.DefaultBrightness;
            brightnessValue.Text = ControlConstants.DefaultBrightness.ToString();

            contrastTrackBar.Value = ControlConstants.DefaultContrast;
            contrastValue.Text = ControlConstants.DefaultContrast.ToString();
        }

        private void BrightnessContrastForm_Load(object sender, EventArgs e)
        {
            ImageProcessingApi = new ImageProcessingApi();         
            ReloadTextFormExtension.ReloadText(this, GetType());
            ReloadTrackbars();
        }

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
       
        public void SetInputImage(object sender, ImageProcessingEventArgs e)
        {
            InputImage = e.Image;
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
            Bitmap preview = new Bitmap(InputImage);
            ImageProcessingApi.BrightnessContrast(preview, brightnessTrackBar.Value, contrastTrackBar.Value);
            OnProcessingCompleted(preview);
        }

        private void contrastTrackbar_ValueChanged(object sender, EventArgs e)
        {
            Bitmap preview = new Bitmap(InputImage);
            ImageProcessingApi.BrightnessContrast(preview, brightnessTrackBar.Value, contrastTrackBar.Value);
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
    }
}
