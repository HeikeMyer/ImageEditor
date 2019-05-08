using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImageProcessing;
using ImageEditor.Constants;

namespace ImageEditor
{
    public partial class BrightnessContrastForm : Form
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


        private Adjustments brightnessContrast;
        private Bitmap input;

        public void SetInputImage(object sender, ImageProcessingEventArgs e)
        {
            input = e.Image;
        }


        public BrightnessContrastForm()
        {
            InitializeComponent();

            brightnessTrackBar.Minimum = ControlValueConstants.MinBrightness;
            brightnessTrackBar.Maximum = ControlValueConstants.MaxBrightness;

            contrastTrackBar.Minimum = ControlValueConstants.MinBrightness;
            contrastTrackBar.Maximum = ControlValueConstants.MaxBrightness;

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
            brightnessContrast = new Adjustments();

            brightnessTrackBar.Value = ControlValueConstants.DefaultBrightness;
            brightnessValue.Text = ControlValueConstants.DefaultBrightness.ToString();

            contrastTrackBar.Value = ControlValueConstants.DefaultContrast;
            contrastValue.Text = ControlValueConstants.DefaultContrast.ToString();
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
            brightnessContrast.AdjustBrightnessAndContrast(preview, brightnessTrackBar.Value, contrastTrackBar.Value);
            OnProcessingCompleted(preview);
        }

        private void contrastTrackbar_ValueChanged(object sender, EventArgs e)
        {
            Bitmap preview = new Bitmap(input);
            brightnessContrast.AdjustBrightnessAndContrast(preview, brightnessTrackBar.Value, contrastTrackBar.Value);
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
    }
}
