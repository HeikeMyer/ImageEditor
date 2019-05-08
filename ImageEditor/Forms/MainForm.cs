using System;
using System.Configuration;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImageProcessing;

namespace ImageEditor.Forms
{
    public partial class MainForm : Form
    {
        public event ImageProcessingEventHandler AdjustmentCall;

        protected virtual void OnAdjustmentCall()
        {
            AdjustmentCall?.Invoke(this, new ImageProcessingEventArgs(workingCopy));
        }

        public delegate void CustomFilterEventHandler(object sender, CustomFilterEventArgs e);

        public event CustomFilterEventHandler CustomFilterCall;

        protected virtual void OnCustomFilterCall(CustomFilter filter, CustomFilterAdjustment adjustment)
        {
            CustomFilterCall?.Invoke(this, new CustomFilterEventArgs(workingCopy, adjustment, filter));
        }


        public delegate void FilterEventHandler(object sender, FilterEventArgs e);

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

        }

        private void Meth(object filterKernel)
        {

            FilterCall?.Invoke(this, new FilterEventArgs(workingCopy, (ConvolutionMatrix)filterKernel));
        }


        FileOperations fileOperations;
        Filter filter;
        BrightnessContrastForm brightnessContrastForm;
        ExposureForm exposureForm;
        CustomFilterForm customFilterForm;
        ColorBalanceForm colorBalanceForm;
        ThresholdForm thresholdForm;


        public MainForm()
        {
            InitializeComponent();

            var lang = ConfigurationManager.AppSettings["Language"];
            //ConfigurationManager.AppSettings["Language"] = "Russian";
            var e = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            e.AppSettings.Settings["Language"].Value = "French";
            e.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");

            var lan2g = ConfigurationManager.AppSettings["Language"];
            

            fileOperations = new FileOperations();

            fileOperations.FileOpened += ReceiveImage;

            filter = new Filter();
            this.FilterCall += filter.ApplyFilter;

            filter.ProcessingCompleted += ViewProcessedImage;
            filter.ProcessingCompleted += ApproveProcessing;
            filter.Middle += React;
            brightnessContrastForm = new BrightnessContrastForm();

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
            exposureForm.ProcessingCompleted += ViewProcessedImage;
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

        private void ReceiveImage(object sender, FileOperations.OpenEventArgs e)
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
            thresholdForm.ShowDialog();
        }

        private void exposureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackUpWorkingCopy();
            OnAdjustmentCall();
            exposureForm.ShowDialog();
        }

        private void sharpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            backup = workingCopy;
            OnFilterCall(Filter.LightSharpenMatrix());
        }

        private void sharpenMoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackUpWorkingCopy();
            OnFilterCall(Filter.SharpenMatrix());
        }

        private void unsharpMaskToolStripMenuItem_Click(object sender, EventArgs e)
        {

            BackUpWorkingCopy();
            OnFilterCall(Filter.UnsharpMasking());
        }

        private void boxBlurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackUpWorkingCopy();
            OnFilterCall(Filter.BoxBlur());
        }

        private void gaussianBlurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackUpWorkingCopy();
            OnFilterCall(Filter.GaussianBlur());
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
            OnFilterCall(Filter.EdgeDetection());

        }

        //private void DoWork(object sender, )

        private void erosionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackUpWorkingCopy();

            CustomFilter customFilter = new CustomFilter();
            CustomFilterAdjustment adjustment = new CustomFilterAdjustment(customFilter.Erosion);

            OnCustomFilterCall(customFilter, adjustment);

            customFilterForm.ShowDialog();
        }

        private void dilutionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackUpWorkingCopy();

            CustomFilter customFilter = new CustomFilter();
            CustomFilterAdjustment adjustment = new CustomFilterAdjustment(customFilter.Dilution);

            OnCustomFilterCall(customFilter, adjustment);

            customFilterForm.ShowDialog();
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
            brightnessContrastForm.ShowDialog();
        }

        private void colorBalanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackUpWorkingCopy();
            OnAdjustmentCall();
            colorBalanceForm.ShowDialog();

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
            CustomFilterAdjustment adjustment = new CustomFilterAdjustment(customFilter.Blur);

            OnCustomFilterCall(customFilter, adjustment);

            customFilterForm.ShowDialog();
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
    }
}
