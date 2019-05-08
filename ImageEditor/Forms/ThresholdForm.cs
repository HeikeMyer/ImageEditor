using System;
using System.Configuration;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using ImageEditor.Constants;
using ImageProcessing;

namespace ImageEditor.Forms
{
    public partial class ThresholdForm : Form
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

        public void SetInputImage(object sender, ImageProcessingEventArgs e)
        {
            input = e.Image;
        }

        private Adjustments threshold;
        private Bitmap input;


        public ThresholdForm()
        {
            InitializeComponent();

            thresholdTrackBar.Minimum = ControlConstants.MinThresholdLevel;
            thresholdTrackBar.Maximum = ControlConstants.MaxThresholdLevel;
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
            Bitmap preview = new Bitmap(input);
            threshold.Threshold(preview, thresholdTrackBar.Value);
            OnProcessingCompleted(preview);
        }

        private void ThresholdForm_Load(object sender, EventArgs e)
        {
            threshold = new Adjustments();

            thresholdTrackBar.Value = ControlConstants.DefaultThresholdLevel;
            thresholdValue.Text = ControlConstants.DefaultThresholdLevel.ToString();

            var cultureCode = ConfigurationManager.AppSettings[ConfigurationConstants.CultureCodeKey];
            FormExtensions.UpdateLanguage(this, GetType(), ReloadControlText, cultureCode);
        }

        public void ReloadControlText(ResourceManager resourceManager)
        {
            labelThresholdLevel.Text = resourceManager.GetString(nameof(labelThresholdLevel) + ControlConstants.TextPropertyName);
            cancelButton.Text = resourceManager.GetString(nameof(cancelButton) + ControlConstants.TextPropertyName);
        }
    }
}
