using System;
using System.Configuration;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using ImageEditor.Constants;
using ImageEditor.Interfaces;
using ImageProcessing;

namespace ImageEditor.Forms
{
    public partial class ExposureForm : Form, IImageProcessingDialogForm
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


       // private Adjustments exposure;
        private Bitmap input;



        public ExposureForm()
        {
            InitializeComponent();
            ImageProcessingApi = new ImageProcessingApi();

            exposureTrackBar.Minimum = ControlConstants.MinExposure;
            exposureTrackBar.Maximum = ControlConstants.MaxExposure;

            gammaTrackBar.Minimum = ControlConstants.MinGamma;
            gammaTrackBar.Maximum = ControlConstants.MaxGamma;
        }

        private void exposureTrackBar_Scroll(object sender, EventArgs e)
        {
            exposureValue.Text = ComputeExposureValue().ToString();
        }

        private void gammaTrackBar_Scroll(object sender, EventArgs e)
        {
            gammaValue.Text = ComputeGammaValue().ToString();
        }

        private void exposureTrackBar_ValueChanged(object sender, EventArgs e)
        {
            Bitmap preview = new Bitmap(input);
            ImageProcessingApi.AdjustExposure(preview, ComputeExposureValue(), ComputeGammaValue());
            OnProcessingCompleted(preview);
        }


        private int ComputeGammaTrackBarValue(double gamma)
        {
            return (int)(gamma < 1 ? gamma * 400 : (gamma - 1) * 400 / 7 + 400);
        }


        private void gammaTrackBar_ValueChanged(object sender, EventArgs e)
        {
            Bitmap preview = new Bitmap(input);
            ImageProcessingApi.AdjustExposure(preview, ComputeExposureValue(), ComputeGammaValue());
            OnProcessingCompleted(preview);
        }

        private void exposureValue_TextChanged(object sender, EventArgs e)
        {


            double value;

            if (Synchronization.IsValueValid(exposureValue.Text, -2, 2, out value))
                exposureTrackBar.Value = (int)(value * 100);

        }

        private void gammaValue_TextChanged(object sender, EventArgs e)
        {
            double value;
            if (Synchronization.IsValueValid(gammaValue.Text, 0.0025, 7.99, out value))
                gammaTrackBar.Value = ComputeGammaTrackBarValue(value);

        }

        private void okButton_Click(object sender, EventArgs e)
        {
            OnProcessingApproved();
            Close();
        }

        private ImageProcessingApi ImageProcessingApi { get; set; }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            OnProcessingCanceled();
            Close();
        }

        private void ExposureForm_Load(object sender, EventArgs e)
        {
            //exposure = new Adjustments();

            exposureTrackBar.Value = ControlConstants.DefaultExposure;
            exposureValue.Text = ControlConstants.DefaultExposure.ToString();

            gammaTrackBar.Value = ControlConstants.DefaultGamma;
            gammaValue.Text = ControlConstants.DefaultGamma.ToString();
            
            ReloadTextFormExtension.ReloadText(this, GetType());
            //ReloadTextFormExtension.ReloadText(this, GetType(), ReloadControlText, cultureCode);
        }

        public void SetInputImage(object sender, ImageProcessingEventArgs e)
        {
            input = e.Image;
        }


        private double ComputeGammaValue()
        {
            return gammaTrackBar.Value < 400 ? gammaTrackBar.Value / 400.0 : (gammaTrackBar.Value - 400.0) * 7 / 400 + 1;
        }


        private double ComputeExposureValue()
        {
            return exposureTrackBar.Value / 100.0;
        }

        public void ReloadControlText(ResourceManager resourceManager)
        {
            exposureLabel.Text = resourceManager.GetString(nameof(exposureLabel) + ControlConstants.TextPropertyName);
            gammaLabel.Text = resourceManager.GetString(nameof(gammaLabel) + ControlConstants.TextPropertyName);
            cancelButton.Text = resourceManager.GetString(nameof(cancelButton) + ControlConstants.TextPropertyName);
        }
    }
}
