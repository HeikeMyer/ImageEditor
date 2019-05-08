using System;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;
using ImageEditor.Constants;

namespace ImageEditor.Operations
{
    class FileOperation
    {
        public const string OpenFileDialogFilter = "Image Files(*.JPG; *.BMP; *.PNG)| *.JPG; *.BMP; *.PNG";
        public const string SaveFileDialogFilter = "JPG Image|*.jpg|BMP Image|*.bmp|PNG Image|*.png";
        public const string CouldNotReadFileErrorMessage = "Error: Could not read file from disk. Original error: ";
        public const string CouldNotWriteFileErrorMessage = "Error: Could not write file to disk. Original error: ";

        public class OpenEventArgs
        {
            public OpenEventArgs(Bitmap bitmap)
            {
                Input = bitmap;
            }

            public Bitmap Input { get; }
        }

        public delegate void OpenFileEventHandler(object sender, OpenEventArgs e);

        public event OpenFileEventHandler FileOpened;

        protected virtual void OnFileOpened(Bitmap input)
        {
            FileOpened?.Invoke(this, new OpenEventArgs(input));
        }
       
        public void OpenImageFile()
        {
            Bitmap input = null;
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = ConfigurationManager.AppSettings[ConfigurationConstants.RootSearchPathKey],
                Filter = OpenFileDialogFilter,
                CheckFileExists = true,
                CheckPathExists = true,
                RestoreDirectory = true
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    input = new Bitmap(Image.FromFile(openFileDialog.FileName));
                }
                catch (Exception exception)
                {
                    MessageBox.Show(CouldNotReadFileErrorMessage + exception.Message);
                }
            }

            OnFileOpened(input);
        }

        public void SaveImageFileAs(Bitmap image)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = SaveFileDialogFilter,
                AddExtension = true,
                OverwritePrompt = true,
                RestoreDirectory = true
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    image.Save(saveFileDialog.FileName);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(CouldNotWriteFileErrorMessage + exception.Message);
                }
            }
        }
    }
}
