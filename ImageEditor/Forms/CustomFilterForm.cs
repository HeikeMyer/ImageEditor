using System;
using System.Drawing;
using System.Windows.Forms;
using ImageEditor.Interfaces;
using ImageProcessing;

namespace ImageEditor.Forms
{
    public partial class CustomFilterForm : Form, IImageProcessingDialogForm
    {
        private Bitmap InputImage { get; set; }

        public ImageProcessingApi ImageProcessingApi { get; set; }

        private Func<Bitmap, int, Bitmap> Adjustment { get; set; }

        private int MaxIntensity { get; set; }

        public CustomFilterForm()
        {
            InitializeComponent();
        }

        private void CustomFilterForm_Load(object sender, EventArgs e)
        {
            intensityValue.Text = "1";
            ReloadTextFormExtension.ReloadText(this, GetType());
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
            InputImage = new Bitmap(e.Image);
            Adjustment = e.Adjustment;
            MaxIntensity = 2 * Synchronization.GetLessValue(InputImage.Height, InputImage.Width) + 1;
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
        
        private void intensityValue_TextChanged(object sender, EventArgs e)
        {
            int value;

            if (!Synchronization.IsValueValid(intensityValue.Text, 1, MaxIntensity, out value))
                return;

            if (value == 1)
            {
                OnProcessingCompleted(InputImage);
                return;
            }
            
            Bitmap preview = new Bitmap(InputImage);
            preview = Adjustment(preview, value);
            OnProcessingCompleted(preview);
        }
    }
}
