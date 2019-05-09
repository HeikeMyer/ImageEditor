using System;
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

namespace ImageEditor.Forms
{
    public partial class MainForm : Form
    {
        public event ImageProcessingEventHandler AdjustmentCall;

        protected virtual void OnAdjustmentCall(CustomFilter filter = null, Func<Bitmap, Bitmap> adjustment = null)
        {
            var imageProcessingEventArgs = new ImageProcessingEventArgs
            {
                Image = workingCopy,
                Filter = filter,
                Adjustment = adjustment
            };

            AdjustmentCall?.Invoke(this, imageProcessingEventArgs);
        }

        public delegate void FilterEventHandler(object sender, FilterEventArgs e);

        public event FilterEventHandler FilterCall;

        protected virtual void OnFilterCall(ConvolutionMatrix filterKernel)
        {
            FilterCall?.Invoke(this, new FilterEventArgs(workingCopy, filterKernel));
        }

        private void Meth(object filterKernel)
        {

            FilterCall?.Invoke(this, new FilterEventArgs(workingCopy, (ConvolutionMatrix)filterKernel));
        }


        FileOperation fileOperations;
        Filter filter;

        
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
    
            fileOperations = new FileOperation();

            fileOperations.FileOpened += ReceiveImage;

            filter = new Filter();
            this.FilterCall += filter.ApplyFilter;

            filter.ProcessingCompleted += ViewProcessedImage;
            filter.ProcessingCompleted += ApproveProcessing;
            filter.Middle += React;
            
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {
          
        }


        private Bitmap original;
        private Bitmap workingCopy;
        private Bitmap backup;

        private void BackUpWorkingCopy()
        {
            backup = (Bitmap)workingCopy?.Clone();
        }

        private void RestoreBackupWorkingCopy()
        {
            workingCopy = (Bitmap)backup?.Clone();
        }

        private void ReceiveImage(object sender, FileOperation.OpenEventArgs e)
        {
            if (e.Input == null)
                return;

            original = e.Input;
            workingCopy = new Bitmap(original);
            backup = new Bitmap(original);
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
            pictureBox.Image = original;
        }

        private void ViewProcessedImage(object sender, ImageProcessingEventArgs e)
        {
            pictureBox.Image = e.Image;
        }

        private void React(object sender, ImageProcessingEventArgs e)
        {
            MessageBox.Show("aa  " + e.Val);
        }

        private void ViewWorkingCopy()
        {
            pictureBox.Image = workingCopy;
        }

        private void ApproveProcessing(object sender, ImageProcessingEventArgs e)
        {
            workingCopy = (Bitmap)pictureBox.Image;
        }

        private void CancelProcessing(object sender, ImageProcessingEventArgs e)
        {
            pictureBox.Image = workingCopy;
        }


        private void imageToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sepiaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            BackUpWorkingCopy();
            Adjustments adjustment = new Adjustments();
            adjustment.Sepia(workingCopy, 0);
            ViewWorkingCopy();
        }

        private void blackAndWhiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackUpWorkingCopy();
            Adjustments adjustment = new Adjustments();
            adjustment.BlackAndWhite(workingCopy, 0);
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
            backup = workingCopy;
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

            CustomFilter customFilter = new CustomFilter();
            //CustomFilterAdjustment adjustment = new CustomFilterAdjustment(customFilter.Erosion);

            // OnCustomFilterCall(customFilter, adjustment);
            OnAdjustmentCall(customFilter, customFilter.Erosion);

            ImageProcessingDialogForms[ControlConstants.CustomFilterFormName].ShowDialog();
        }

        private void dilutionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackUpWorkingCopy();

            CustomFilter customFilter = new CustomFilter();
            //CustomFilterAdjustment adjustment = new CustomFilterAdjustment(customFilter.Dilution);

            //OnCustomFilterCall(customFilter, adjustment);
            OnAdjustmentCall(customFilter, customFilter.Dilution);

            ImageProcessingDialogForms[ControlConstants.CustomFilterFormName].ShowDialog();
        }

        private void invertToolStripMenuItem_Click(object sender, EventArgs e)
        {

            BackUpWorkingCopy();
            Adjustments adjustment = new Adjustments();
            adjustment.Invert(workingCopy, 0);
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

            fileOperations.OpenImageFile();
            ViewOriginalImage();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox.Image = pictureBox.ErrorImage;
            DisableButtons();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileOperations.SaveImageFileAs(workingCopy);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        // unknwn
        private void averageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackUpWorkingCopy();

            CustomFilter customFilter = new CustomFilter();
            OnAdjustmentCall(customFilter, customFilter.Blur);
            //CustomFilterAdjustment adjustment = new CustomFilterAdjustment(customFilter.Blur);

            //OnCustomFilterCall(customFilter, adjustment);

            ImageProcessingDialogForms[ControlConstants.CustomFilterFormName].ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            DisableButtons();
        }

        private void imageToolStripDropDownButton_Click(object sender, EventArgs e)
        {

        }

        private void adjustmentsStripDropDownButton_Click(object sender, EventArgs e)
        {

        }

        private void photoFilterToolStripDropDownButton_Click(object sender, EventArgs e)
        {

        }

        private void filterToolStripDropDownButton_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox_Click(object sender, EventArgs e)
        {

        }

        private void topToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurationOperation.UpdateAppSettings(ConfigurationConstants.CultureCodeKey, ConfigurationConstants.EnglishCultureCode);
            ReloadTextFormExtension.ReloadText(this, GetType());
           // ReloadChildFormsText();
        }

        private void russianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurationOperation.UpdateAppSettings(ConfigurationConstants.CultureCodeKey, ConfigurationConstants.RussianCultureCode);
            ReloadTextFormExtension.ReloadText(this, GetType());
           // ReloadChildFormsText();
        }

        
    }
}
