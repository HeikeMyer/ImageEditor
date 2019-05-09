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
using ImageProcessing.Base;

namespace ImageEditor.Forms
{
    public partial class MainForm : Form
    {
        public event ImageProcessingEventHandler AdjustmentCall;

        ImageProcessingApi ImageProcessingApi { get; set; }

        protected virtual void OnAdjustmentCall(ImageProcessingEventArgs imageProcessingEventArgs)
        {
            /*var imageProcessingEventArgs = new ImageProcessingEventArgs
            {
                Image = workingCopy,
                Filter = filter,
                Adjustment = adjustment
            };*/

            AdjustmentCall?.Invoke(this, imageProcessingEventArgs);
        }

        

       // public delegate void CustomFilterEventHandler(object sender, CustomFilterEventArgs e);

       // public event CustomFilterEventHandler CustomFilterCall;

      /*  protected virtual void OnCustomFilterCall(CustomFilter filter, Func<Bitmap, Bitmap> adjustment)
        {
            CustomFilterCall?.Invoke(this, new CustomFilterEventArgs(workingCopy, adjustment, filter));
        }*/


        /*public delegate void FilterEventHandler(object sender, FilterEventArgs e);

        public event FilterEventHandler FilterCall;

        protected virtual void OnFilterCall(ConvolutionMatrix filterKernel)
        {
            //Task task = new Task(() => Meth(filterKernel));
            //Thread thread = new Thread(Meth)
            //DisableButtons();
            //task.Start();
            //task.Wait();
            //EnableButtons();
            FilterCall?.Invoke(this, new FilterEventArgs(workingCopy, filterKernel));
            //var res = FilterCall?.BeginInvoke(this, new FilterEventArgs(workingCopy, filterKernel), null, null);
            //FilterCall?.EndInvoke(res);
            //var i = 10;
            //Thread t = new Thread(new ParameterizedThreadStart(Meth));

            //Thread t = new Thread()

        }*/

        /*private void Meth(object filterKernel)
        {

            FilterCall?.Invoke(this, new FilterEventArgs(workingCopy, (ConvolutionMatrix)filterKernel));
        }*/


        FileOperation fileOperations;
        Filter filter;

        /*BrightnessContrastForm brightnessContrastForm;
        ExposureForm exposureForm;
        CustomFilterForm customFilterForm;
        ColorBalanceForm colorBalanceForm;
        ThresholdForm thresholdForm;*/
        
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
            ImageProcessingApi = new ImageProcessingApi();
            CreateImageProcessingDialogForms();
            SetImageProcessingDialogFormsEventHandlers();

           
            ReloadTextFormExtension.ReloadText(this, GetType());
            //ReloadTextFormExtension.ReloadText(this, GetType(), ReloadControlText, cultureCode);

            fileOperations = new FileOperation();

            fileOperations.FileOpened += ReceiveImage;

            filter = new Filter();
            this.AdjustmentCall += filter.ApplyFilter;

            filter.ProcessingCompleted += ViewProcessedImage;
            filter.ProcessingCompleted += ApproveProcessing;
            filter.Middle += React;
            /*brightnessContrastForm = new BrightnessContrastForm();

            this.AdjustmentCall += brightnessContrastForm.SetInputImage;

            brightnessContrastForm.ProcessingApproved += ApproveProcessing;
            brightnessContrastForm.ProcessingCanceled += CancelProcessing;
            brightnessContrastForm.ProcessingCompleted += ViewProcessedImage;

            colorBalanceForm = new ColorBalanceForm();
            this.AdjustmentCall += colorBalanceForm.SetInputImage;

            colorBalanceForm.ProcessingApproved += ApproveProcessing;
            colorBalanceForm.ProcessingCanceled += CancelProcessing;
            colorBalanceForm.ProcessingCompleted += ViewProcessedImage;

            thresholdForm = new ThresholdForm();
            this.AdjustmentCall += thresholdForm.SetInputImage;

            thresholdForm.ProcessingApproved += ApproveProcessing;
            thresholdForm.ProcessingCanceled += CancelProcessing;
            thresholdForm.ProcessingCompleted += ViewProcessedImage;

            customFilterForm = new CustomFilterForm();
            this.CustomFilterCall += customFilterForm.SetInputImage;

            customFilterForm.ProcessingApproved += ApproveProcessing;
            customFilterForm.ProcessingCanceled += CancelProcessing;
            customFilterForm.ProcessingCompleted += ViewProcessedImage;

            exposureForm = new ExposureForm();
            this.AdjustmentCall += exposureForm.SetInputImage;

            exposureForm.ProcessingApproved += ApproveProcessing;
            exposureForm.ProcessingCanceled += CancelProcessing;
            exposureForm.ProcessingCompleted += ViewProcessedImage;*/
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
            MessageBox.Show("aa  " + e.Progress);
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
            ImageProcessingApi.Sepia(workingCopy, 0);
            ViewWorkingCopy();
        }

        private void blackAndWhiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackUpWorkingCopy();
            Adjustments adjustment = new Adjustments();
            ImageProcessingApi.BnW(workingCopy, 0);
            ViewWorkingCopy();
        }

        private void thresholdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackUpWorkingCopy();
            OnAdjustmentCall(new ImageProcessingEventArgs { Image = workingCopy });
            ImageProcessingDialogForms[ControlConstants.ThresholdFormName].ShowDialog();
        }

        private void exposureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackUpWorkingCopy();
            OnAdjustmentCall(new ImageProcessingEventArgs { Image = workingCopy });
            ImageProcessingDialogForms[ControlConstants.ExposureFormName].ShowDialog();
        }

        private void sharpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            backup = workingCopy;
            var imageProcessingEventArgs = new ImageProcessingEventArgs
            {
                Image = workingCopy,
                ConvolutionMatrix = ConvolutionMatrices.LightSharpenMatrix()
            };

            OnAdjustmentCall(imageProcessingEventArgs);
        }

        private void sharpenMoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackUpWorkingCopy();
            var imageProcessingEventArgs = new ImageProcessingEventArgs
            {
                Image = workingCopy,
                ConvolutionMatrix = ConvolutionMatrices.SharpenMatrix()
            };

            OnAdjustmentCall(imageProcessingEventArgs);

            //OnFilterCall(ConvolutionMatrices.SharpenMatrix());
        }

        private void unsharpMaskToolStripMenuItem_Click(object sender, EventArgs e)
        {

            BackUpWorkingCopy();
            var imageProcessingEventArgs = new ImageProcessingEventArgs
            {
                Image = workingCopy,
                ConvolutionMatrix = ConvolutionMatrices.UnsharpMasking()
            };

            OnAdjustmentCall(imageProcessingEventArgs);

            // OnFilterCall(ConvolutionMatrices.UnsharpMasking());
        }

        private void boxBlurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackUpWorkingCopy();
            var imageProcessingEventArgs = new ImageProcessingEventArgs
            {
                Image = workingCopy,
                ConvolutionMatrix = ConvolutionMatrices.BoxBlur()
            };

            OnAdjustmentCall(imageProcessingEventArgs);

            // OnFilterCall(ConvolutionMatrices.BoxBlur());
        }

        private void gaussianBlurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackUpWorkingCopy();
            var imageProcessingEventArgs = new ImageProcessingEventArgs
            {
                Image = workingCopy,
                ConvolutionMatrix = ConvolutionMatrices.GaussianBlur()
            };

            OnAdjustmentCall(imageProcessingEventArgs);

            //OnFilterCall(ConvolutionMatrices.GaussianBlur());
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
           // OnFilterCall(ConvolutionMatrices.EdgeDetection());

        }

        //private void DoWork(object sender, )

        private void erosionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackUpWorkingCopy();

            CustomFilter customFilter = new CustomFilter();
            //CustomFilterAdjustment adjustment = new CustomFilterAdjustment(customFilter.Erosion);

            // OnCustomFilterCall(customFilter, adjustment);
            // OnAdjustmentCall(customFilter, customFilter.Erosion);
            var imageProcessingEventArgs = new ImageProcessingEventArgs
            {
                Image = workingCopy,
                Filter = customFilter,
                Adjustment = customFilter.Erosion
                //ConvolutionMatrix = ConvolutionMatrices.LightSharpenMatrix()
            };

            OnAdjustmentCall(imageProcessingEventArgs);


            ImageProcessingDialogForms[ControlConstants.CustomFilterFormName].ShowDialog();
        }

        private void dilutionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackUpWorkingCopy();

            CustomFilter customFilter = new CustomFilter();
            //CustomFilterAdjustment adjustment = new CustomFilterAdjustment(customFilter.Dilution);

            //OnCustomFilterCall(customFilter, adjustment);
            // OnAdjustmentCall(customFilter, customFilter.Dilution);
            var imageProcessingEventArgs = new ImageProcessingEventArgs
            {
                Image = workingCopy,
                Filter = customFilter,
                Adjustment = customFilter.Dilution
                //ConvolutionMatrix = ConvolutionMatrices.LightSharpenMatrix()
            };



            ImageProcessingDialogForms[ControlConstants.CustomFilterFormName].ShowDialog();
        }

        private void invertToolStripMenuItem_Click(object sender, EventArgs e)
        {

            BackUpWorkingCopy();
            Adjustments adjustment = new Adjustments();
            ImageProcessingApi.Invert(workingCopy, 0);
            ViewWorkingCopy();
        }

        private void brightnessContrastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackUpWorkingCopy();
            OnAdjustmentCall(new ImageProcessingEventArgs { Image = workingCopy });
            ImageProcessingDialogForms[ControlConstants.BrightnessContrastFormName].ShowDialog();
        }

        private void colorBalanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackUpWorkingCopy();
            OnAdjustmentCall(new ImageProcessingEventArgs { Image = workingCopy });
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
            var imageProcessingEventArgs = new ImageProcessingEventArgs
            {
                Image = workingCopy,
                Filter = customFilter,
                Adjustment = customFilter.Erosion
                //ConvolutionMatrix = ConvolutionMatrices.LightSharpenMatrix()
            };


            OnAdjustmentCall(imageProcessingEventArgs);
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

        private void adjustmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void blurToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        /*private void ReloadChildFormsText()
        {
            ReloadTextFormExtension.ReloadText(brightnessContrastForm, GetType());
            ReloadTextFormExtension.ReloadText(colorBalanceForm, GetType());
            ReloadTextFormExtension.ReloadText(exposureForm, GetType());
            ReloadTextFormExtension.ReloadText(customFilterForm, GetType());
            ReloadTextFormExtension.ReloadText(thresholdForm, GetType());
        }*/

    }
}
