using System;
using System.Drawing;
using System.Windows.Forms;
using ImageEditor.Constants;
using ImageEditor.Interfaces;
using ImageProcessing;

namespace ImageEditor.Forms
{
    public partial class ThresholdForm : Form, IImageProcessingDialogForm
    {
        private Bitmap InputImage { get; set; }

        public ImageProcessingApi ImageProcessingApi { get; set; }

        private void InitializeTrackbars()
        {
            thresholdTrackBar.Minimum = ControlConstants.MinThresholdLevel;
            thresholdTrackBar.Maximum = ControlConstants.MaxThresholdLevel;
        }

        public ThresholdForm()
        {
            InitializeComponent();
            InitializeTrackbars();
        }

        private void ReloadTrackbars()
        {
            thresholdTrackBar.Value = ControlConstants.DefaultThresholdLevel;
            thresholdValue.Text = ControlConstants.DefaultThresholdLevel.ToString();
        }

        private void ThresholdForm_Load(object sender, EventArgs e)
        {
           // ImageProcessingApi = new ImageProcessingApi();
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

        private void thresholdValue_TextChanged(object sender, EventArgs e)
        {
            Synchronization.SynchronizeTrackBar(thresholdTrackBar, thresholdValue);
        }

        private void thresholdTrackBar_Scroll(object sender, EventArgs e)
        {
            Synchronization.SynchronizeTextBox(thresholdValue, thresholdTrackBar);
        }

        private void thresholdTrackBar_ValueChanged(object sender, EventArgs e)
        {
            Bitmap preview = new Bitmap(InputImage);
            ImageProcessingApi.Threshold(preview, thresholdTrackBar.Value);
            OnProcessingCompleted(preview);
        }
    }
}
