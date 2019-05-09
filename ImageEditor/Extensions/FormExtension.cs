using System;
using System.Threading;
using System.Windows.Forms;

namespace ImageEditor
{
    public static class FormExtension
    {
        public static void LaunchBackgroundThread(this Form form, Action action)
        {
            var thread = new Thread(new ThreadStart(action)) { IsBackground = true };
            thread.Start();
        }
    }
}
