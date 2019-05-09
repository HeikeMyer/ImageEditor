using System.Windows.Forms;
using ImageProcessing;

namespace ImageEditor.Interfaces
{
    public interface IImageProcessingDialogForm
    {
        event ImageProcessingEventHandler ProcessingApproved;
        event ImageProcessingEventHandler ProcessingCanceled;
        event ImageProcessingEventHandler ProcessingCompleted;

        void SetInputImage(object sender, ImageProcessingEventArgs e);

        ImageProcessingApi ImageProcessingApi { get; set; }

        DialogResult ShowDialog();
    }
}
