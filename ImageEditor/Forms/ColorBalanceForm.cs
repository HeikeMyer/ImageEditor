using System;
using System.Drawing;
using System.Windows.Forms;
using ImageEditor.Constants;
using ImageEditor.Interfaces;
using ImageProcessing;

namespace ImageEditor.Forms
{
    public partial class ColorBalanceForm : Form, IImageProcessingDialogForm
    {
        private Bitmap InputImage { get; set; }

        public ImageProcessingApi ImageProcessingApi { get; set; }

        private void InitializeTrackbars()
        {
            redTrackBar.Minimum = greenTrackBar.Minimum = blueTrackBar.Minimum = ControlConstants.MinColorBalance;
            redTrackBar.Maximum = greenTrackBar.Maximum = blueTrackBar.Maximum = ControlConstants.MaxColorBalance;
        }

        public ColorBalanceForm()
        {
            InitializeComponent();
            InitializeTrackbars();
        }

        private void ReloadTrackbars()
        {
            redTrackBar.Value = greenTrackBar.Value = blueTrackBar.Value = ControlConstants.DefaultColorBalance;
            redValue.Text = greenValue.Text = blueValue.Text = ControlConstants.DefaultColorBalance.ToString();
        }

        private void ColorBalanceForm_Load(object sender, EventArgs e)
        {
            //ImageProcessingApi = new ImageProcessingApi();
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

        private void redValue_TextChanged(object sender, EventArgs e)
        {
            Synchronization.SynchronizeTrackBar(redTrackBar, redValue);
        }

        private void greenValue_TextChanged(object sender, EventArgs e)
        {
            Synchronization.SynchronizeTrackBar(greenTrackBar, greenValue);
        }

        private void blueValue_TextChanged(object sender, EventArgs e)
        {
            Synchronization.SynchronizeTrackBar(blueTrackBar, blueValue);
        }

        private void redTrackBar_Scroll(object sender, EventArgs e)
        {
            Synchronization.SynchronizeTextBox(redValue, redTrackBar);
        }

        private void greenTrackBar_Scroll(object sender, EventArgs e)
        {
            Synchronization.SynchronizeTextBox(greenValue, greenTrackBar);
        }

        private void blueTrackBar_Scroll(object sender, EventArgs e)
        {
            Synchronization.SynchronizeTextBox(blueValue, blueTrackBar);
        }

        private void redTrackBar_ValueChanged(object sender, EventArgs e)
        {
            Bitmap preview = new Bitmap(InputImage);
            ImageProcessingApi.ColorBalance(preview, redTrackBar.Value, greenTrackBar.Value, blueTrackBar.Value);
            OnProcessingCompleted(preview);
        }

        private void greenTrackBar_ValueChanged(object sender, EventArgs e)
        {
            Bitmap preview = new Bitmap(InputImage);
            ImageProcessingApi.ColorBalance(preview, redTrackBar.Value, greenTrackBar.Value, blueTrackBar.Value);
            OnProcessingCompleted(preview);

        }

        private void blueTrackBar_ValueChanged(object sender, EventArgs e)
        {
            Bitmap preview = new Bitmap(InputImage);
            ImageProcessingApi.ColorBalance(preview, redTrackBar.Value, greenTrackBar.Value, blueTrackBar.Value);
            OnProcessingCompleted(preview);

        }
    }
}
