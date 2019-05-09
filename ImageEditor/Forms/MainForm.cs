﻿using System;
using System.Configuration;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImageProcessing;
using ImageEditor.Operations;
using System.Resources;
using ImageEditor.Constants;
using System.Collections.Generic;
using System.Linq;
using ImageEditor.Interfaces;
using ImageProcessing.Base;

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
                { ControlConstants.BrightnessContrastFormName, new BrightnessContrastForm() },
                { ControlConstants.ColorBalanceFilterFormName, new ColorBalanceForm() },
                { ControlConstants.CustomFilterFormName, new CustomFilterForm() },
                { ControlConstants.ExposureFormName, new ExposureForm() },
                { ControlConstants.ThresholdFormName, new ThresholdForm() }
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
            CreateImageProcessingDialogForms();
            SetImageProcessingDialogFormsEventHandlers();
            
            ReloadTextFormExtension.ReloadText(this, GetType());

            FileOperation = new FileOperation();

            FileOperation.FileOpened += ReceiveImage;

            ImageProcessingApi = new ImageProcessingApi();
            this.FilterCall += ImageProcessingApi.ApplyFilter;

            ImageProcessingApi.ProcessingCompleted += ViewProcessedImage;
            ImageProcessingApi.ProcessingCompleted += ApproveProcessing;
            ImageProcessingApi.Progress += React;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            DisableButtons();
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

        private void React(object sender, ImageProcessingEventArgs e)
        {
            // MessageBox.Show("aa  " + e.Val);
            Invoke(new Action(() => progressBar.Value++ ));
            //progressBar.Value++;
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
        
        private void sepiaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            BackUpWorkingCopy();
            ImageProcessingApi adjustment = new ImageProcessingApi();
            adjustment.Sepia(WorkingImage, 0);
            ViewWorkingCopy();
        }

        private void blackAndWhiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackUpWorkingCopy();
            ImageProcessingApi adjustment = new ImageProcessingApi();
            adjustment.BnW(WorkingImage, 0);
            ViewWorkingCopy();
        }

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

        private void sharpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackupImage = WorkingImage;
            OnFilterCall(ConvolutionMatrices.LightSharpenMatrix());
        }

        private void sharpenMoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackUpWorkingCopy();
            OnFilterCall(ConvolutionMatrices.SharpenMatrix());
        }

        private void unsharpMaskToolStripMenuItem_Click(object sender, EventArgs e)
        {

            BackUpWorkingCopy();
            OnFilterCall(ConvolutionMatrices.UnsharpMasking());
        }

        private void boxBlurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackUpWorkingCopy();
            OnFilterCall(ConvolutionMatrices.BoxBlur());
        }

        private void gaussianBlurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackUpWorkingCopy();
            OnFilterCall(ConvolutionMatrices.GaussianBlur());
        }

        private void edgeDetectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //BackUpWorkingCopy();
            //OnFilterCall(Filter.EdgeDetection());
            Thread t = new Thread(A);
            t.IsBackground = true;
            t.Start();
        }

        private void A()
        {
            OnFilterCall(ConvolutionMatrices.EdgeDetection());

        }

        //private void DoWork(object sender, )

        private void erosionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackUpWorkingCopy();

            ImageProcessingApi customFilter = new ImageProcessingApi();
            //CustomFilterAdjustment adjustment = new CustomFilterAdjustment(customFilter.Erosion);

            // OnCustomFilterCall(customFilter, adjustment);
            OnAdjustmentCall(customFilter, customFilter.Erosion);

            ImageProcessingDialogForms[ControlConstants.CustomFilterFormName].ShowDialog();
        }

        private void dilutionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackUpWorkingCopy();

            ImageProcessingApi customFilter = new ImageProcessingApi();
            //CustomFilterAdjustment adjustment = new CustomFilterAdjustment(customFilter.Dilution);

            //OnCustomFilterCall(customFilter, adjustment);
            OnAdjustmentCall(customFilter, customFilter.Dilution);

            ImageProcessingDialogForms[ControlConstants.CustomFilterFormName].ShowDialog();
        }

        private void invertToolStripMenuItem_Click(object sender, EventArgs e)
        {

            BackUpWorkingCopy();
            ImageProcessingApi adjustment = new ImageProcessingApi();
            adjustment.Invert(WorkingImage, 0);
            ViewWorkingCopy();
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

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RestoreBackupWorkingCopy();
            ViewWorkingCopy();
        }

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

        // unknwn
        private void averageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackUpWorkingCopy();

            ImageProcessingApi customFilter = new ImageProcessingApi();
            OnAdjustmentCall(customFilter, customFilter.Blur);
            //CustomFilterAdjustment adjustment = new CustomFilterAdjustment(customFilter.Blur);

            //OnCustomFilterCall(customFilter, adjustment);

            ImageProcessingDialogForms[ControlConstants.CustomFilterFormName].ShowDialog();
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
    }
}
