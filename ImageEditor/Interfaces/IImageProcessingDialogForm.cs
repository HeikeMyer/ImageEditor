using ImageProcessing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageEditor.Interfaces
{
    public interface IImageProcessingDialogForm
    {
        event ImageProcessingEventHandler ProcessingApproved;
        event ImageProcessingEventHandler ProcessingCanceled;
        event ImageProcessingEventHandler ProcessingCompleted;
        void SetInputImage(object sender, ImageProcessingEventArgs e);
        DialogResult ShowDialog();
    }
}
