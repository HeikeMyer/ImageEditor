using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using ImageProcessing;
using ImageProcessing.Base;
using ImageEditor.Constants;
using ImageEditor.Interfaces;
using ImageEditor.Operations;

namespace ImageEditor.Forms
{
    public partial class MainForm : Form
    {
        private Bitmap OriginalImage { get; set; }

        private Bitmap WorkingImage { get; set; }

        private Bitmap BackupImage { get; set; }

        private ImageProcessingApi ImageProcessingApi { get; set; }

        private FileOperation FileOperation { get; set; }

        private Dictionary<string, IImageProcessingDialogForm> ImageProcessingDialogForms { get; set; }

        private void CreateImageProcessingDialogForms()
        {
            ImageProcessingDialogForms = new Dictionary<string, IImageProcessingDialogForm>
            {
                { ControlConstants.BrightnessContrastFormName, new BrightnessContrastForm{ ImageProcessingApi = ImageProcessingApi }},
                { ControlConstants.ColorBalanceFilterFormName, new ColorBalanceForm{ ImageProcessingApi = ImageProcessingApi }},
                { ControlConstants.CustomFilterFormName, new CustomFilterForm{ ImageProcessingApi = ImageProcessingApi }},
                { ControlConstants.ExposureFormName, new ExposureForm{ ImageProcessingApi = ImageProcessingApi }},
                { ControlConstants.ThresholdFormName, new ThresholdForm{ ImageProcessingApi = ImageProcessingApi }}
            };
        }

        private void SetImageProcessingDialogFormsEventHandlers()
        {
            foreach (var keyValuePair in ImageProcessingDialogForms)
            {
                var form = keyValuePair.Value;

                AdjustmentCall += form.SetInputImage;

                form.ProcessingApproved += ApproveProcessing;
                form.ProcessingCanceled += CancelProcessing;
                form.ProcessingCompleted += ViewProcessedImage;
            }
        }

        public MainForm()
        {
            InitializeComponent();

            ImageProcessingApi = new ImageProcessingApi();

            CreateImageProcessingDialogForms();
            SetImageProcessingDialogFormsEventHandlers();
            
            FileOperation = new FileOperation();

            FileOperation.FileOpened += ReceiveImage;

            FilterCall += ImageProcessingApi.ApplyFilter;

            ImageProcessingApi.ProcessingCompleted += ViewProcessedImage;
            ImageProcessingApi.ProcessingCompleted += ApproveProcessing;
            ImageProcessingApi.ProcessingCompleted += ReloadProgresBar;
            ImageProcessingApi.Progress += OnProgress;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ReloadTextFormExtension.ReloadText(this, GetType());
            DisableButtons();
            progressBar.Visible = false;
        }

        public event ImageProcessingEventHandler AdjustmentCall;

        protected virtual void OnAdjustmentCall(ImageProcessingApi filter = null, Func<Bitmap, int, Bitmap> adjustment = null)
        {
            var imageProcessingEventArgs = new ImageProcessingEventArgs
            {
                Image = WorkingImage,
                Filter = filter,
                Adjustment = adjustment
            };

            AdjustmentCall?.Invoke(this, imageProcessingEventArgs);
        }

        public delegate void FilterEventHandler(object sender, FilterEventArgs e);

        public event FilterEventHandler FilterCall;

        protected virtual void OnFilterCall(ConvolutionMatrix filterKernel)
        {
            FilterCall?.Invoke(this, new FilterEventArgs(WorkingImage, filterKernel));
        }

        private void Meth(object filterKernel)
        {

            FilterCall?.Invoke(this, new FilterEventArgs(WorkingImage, (ConvolutionMatrix)filterKernel));
        }
        
        private void BackUpWorkingCopy()
        {
            BackupImage = (Bitmap)WorkingImage?.Clone();
        }

        private void RestoreBackupWorkingCopy()
        {
            WorkingImage = (Bitmap)BackupImage?.Clone();
        }

        private void ReceiveImage(object sender, FileOperation.OpenEventArgs e)
        {
            if (e.Input == null)
                return;

            OriginalImage = e.Input;
            WorkingImage = new Bitmap(OriginalImage);
            BackupImage = new Bitmap(OriginalImage);
            EnableButtons();
        }

        private void EnableButtons()
        {
            this.adjustmentsToolStripMenuItem.Enabled = true;
            this.imageToolStripDropDownButton.Enabled = true;
            this.filterToolStripDropDownButton.Enabled = true;
            this.photoFilterToolStripMenuItem.Enabled = true;
            this.saveAsToolStripMenuItem.Enabled = true;
            this.closeToolStripMenuItem.Enabled = true;
        }

        private void DisableButtons()
        {
            this.adjustmentsToolStripMenuItem.Enabled = false;
            this.imageToolStripDropDownButton.Enabled = false;
            this.filterToolStripDropDownButton.Enabled = false;
            this.photoFilterToolStripMenuItem.Enabled = false;
            this.saveAsToolStripMenuItem.Enabled = false;
            this.closeToolStripMenuItem.Enabled = false;
        }

        private void ViewOriginalImage()
        {
            pictureBox.Image = OriginalImage;
        }

        private void ViewProcessedImage(object sender, ImageProcessingEventArgs e)
        {
            pictureBox.Image = e.Image;
        }

        private void ReloadProgresBar(object sender, ImageProcessingEventArgs e)
        {
            Invoke(new Action(() =>
            {
                progressBar.Value = progressBar.Maximum;
                progressBar.Visible = false;
                progressBar.Value = progressBar.Minimum;
            }));
        }

        private void OnProgress(object sender, ImageProcessingEventArgs e)
        {
            Invoke(new Action(() => 
            {
                progressBar.Visible = true;
                if (progressBar.Value < progressBar.Maximum)
                    progressBar.Value += 5;
            }));
        }

        private void ViewWorkingCopy()
        {
            pictureBox.Image = WorkingImage;
        }

        private void ApproveProcessing(object sender, ImageProcessingEventArgs e)
        {
            WorkingImage = (Bitmap)pictureBox.Image;
        }

        private void CancelProcessing(object sender, ImageProcessingEventArgs e)
        {
            pictureBox.Image = WorkingImage;
        }

        #region [Adjustments (no dialog)]

        private void sepiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackUpWorkingCopy();
            ImageProcessingApi.Sepia(WorkingImage, 0);
            ViewWorkingCopy();
        }

        private void blackAndWhiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackUpWorkingCopy();
            ImageProcessingApi.BnW(WorkingImage, 0);
            ViewWorkingCopy();
        }

        private void invertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackUpWorkingCopy();
            ImageProcessingApi.Invert(WorkingImage, 0);
            ViewWorkingCopy();
        }

        #endregion

        #region [Filters (no dialog)]

        private void sharpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackUpWorkingCopy();
            this.LaunchBackgroundThread(() => OnFilterCall(ConvolutionMatrices.LightSharpenMatrix()));
        }

        private void sharpenMoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackUpWorkingCopy();
            this.LaunchBackgroundThread(() => OnFilterCall(ConvolutionMatrices.SharpenMatrix()));
        }

        private void unsharpMaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackUpWorkingCopy();
            this.LaunchBackgroundThread(() => OnFilterCall(ConvolutionMatrices.UnsharpMasking()));
        }

        private void boxBlurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackUpWorkingCopy();
            this.LaunchBackgroundThread(() => OnFilterCall(ConvolutionMatrices.BoxBlur()));
        }

        private void gaussianBlurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackUpWorkingCopy();
            this.LaunchBackgroundThread(() => OnFilterCall(ConvolutionMatrices.GaussianBlur()));
        }

        private void edgeDetectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackUpWorkingCopy();
            this.LaunchBackgroundThread(() => OnFilterCall(ConvolutionMatrices.EdgeDetection()));
        }

        #endregion

        #region [CustomFilter]

        private void erosionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackUpWorkingCopy();
            OnAdjustmentCall(ImageProcessingApi, ImageProcessingApi.Erosion);
            ImageProcessingDialogForms[ControlConstants.CustomFilterFormName].ShowDialog();
        }

        private void dilutionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackUpWorkingCopy();
            OnAdjustmentCall(ImageProcessingApi, ImageProcessingApi.Dilution);
            ImageProcessingDialogForms[ControlConstants.CustomFilterFormName].ShowDialog();
        }

        #endregion

        #region [Adjustments]

        private void thresholdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackUpWorkingCopy();
            OnAdjustmentCall();
            ImageProcessingDialogForms[ControlConstants.ThresholdFormName].ShowDialog();
        }

        private void exposureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackUpWorkingCopy();
            OnAdjustmentCall();
            ImageProcessingDialogForms[ControlConstants.ExposureFormName].ShowDialog();
        }

        private void brightnessContrastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackUpWorkingCopy();
            OnAdjustmentCall();
            ImageProcessingDialogForms[ControlConstants.BrightnessContrastFormName].ShowDialog();
        }

        private void colorBalanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackUpWorkingCopy();
            OnAdjustmentCall();
            ImageProcessingDialogForms[ControlConstants.ColorBalanceFilterFormName].ShowDialog();
        }

        #endregion

        #region [Management]
        
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileOperation.OpenImageFile();
            ViewOriginalImage();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox.Image = pictureBox.ErrorImage;
            DisableButtons();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileOperation.SaveImageFileAs(WorkingImage);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
                        
        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurationOperation.UpdateAppSettings(ConfigurationConstants.CultureCodeKey, ConfigurationConstants.EnglishCultureCode);
            ReloadTextFormExtension.ReloadText(this, GetType());
        }

        private void russianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurationOperation.UpdateAppSettings(ConfigurationConstants.CultureCodeKey, ConfigurationConstants.RussianCultureCode);
            ReloadTextFormExtension.ReloadText(this, GetType());
        }

        #endregion

        private void undoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            RestoreBackupWorkingCopy();
            ViewWorkingCopy();
        }
    }
}
