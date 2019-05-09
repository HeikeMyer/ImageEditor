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
    public partial class CustomFilterForm : Form, IImageProcessingDialogForm
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


        private CustomFilter customFilter;
        private Bitmap input;
        private Func<Bitmap, int, Bitmap> adjustment;
       // private CustomFilterAdjustment adjustment;
        private int maximalIntensity;


       /* public void SetInputImage(object sender, CustomFilterEventArgs e)
        {
            input = new Bitmap(e.Input);
            customFilter = e.Filter;
            adjustment = e.Adjustment;
            maximalIntensity = 2 * Synchronization.GetLessValue(input.Height, input.Width) + 1;
        }*/

        public void ReloadControlText(ResourceManager resourceManager)
        {
            intensityLabel.Text = resourceManager.GetString(nameof(intensityLabel) + ControlConstants.TextPropertyName);
        }

        public CustomFilterForm()
        {
            InitializeComponent();
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

        private void CustomFilterForm_Load(object sender, EventArgs e)
        {
            intensityValue.Text = "1";
            ReloadTextFormExtension.ReloadText(this, GetType());
            // ReloadTextFormExtension.ReloadText(this, GetType(), ReloadControlText, cultureCode);
        }

        private void intensityValue_TextChanged(object sender, EventArgs e)
        {
            int value;

            if (!Synchronization.IsValueValid(intensityValue.Text, 1, maximalIntensity, out value))
                return;

            if (value == 1)
            {
                OnProcessingCompleted(input);
                return;
            }

            customFilter.SetUp(value);
            Bitmap preview = new Bitmap(input);
            preview = adjustment(preview, value);
            OnProcessingCompleted(preview);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void SetInputImage(object sender, ImageProcessingEventArgs e)
        {
            var i = 10;
            input = new Bitmap(e.Image);
            customFilter = e.Filter;
            adjustment = e.Adjustment;
            maximalIntensity = 2 * Synchronization.GetLessValue(input.Height, input.Width) + 1;
            //throw new NotImplementedException();
        }
    }
}
