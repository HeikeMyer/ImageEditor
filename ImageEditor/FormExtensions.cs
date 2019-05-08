using System;
using System.Globalization;
using System.Threading;
using System.Resources;
using System.Windows.Forms;
using ImageEditor.Constants;

namespace ImageEditor
{
    public static class FormExtensions
    {
        public static void UpdateLanguage(this Form form, Type type, Action<ResourceManager> reloadControlTextAction, string cultureCode)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureCode);
            ResourceManager resourceManager = new ResourceManager(type);
            form.Text = resourceManager.GetString(nameof(ControlConstants.FormTextResourceString));
            reloadControlTextAction(resourceManager);
        }

        public static void SetTextFromResourceString(this ToolStripMenuItem toolStripMenuItem, ResourceManager resourceManager)
        {
            toolStripMenuItem.Text = resourceManager.GetString(nameof(toolStripMenuItem) + ControlConstants.TextPropertyName);
        }

        public static void SetTextFromResourceString(this Button button, ResourceManager resourceManager)
        {
            button.Text = resourceManager.GetString(nameof(button) + ControlConstants.TextPropertyName);
        }

        public static void ReloadText(this ToolStripDropDownButton button, ResourceManager resourceManager)
        {

        }

        public static void ReloadText(this ToolStrip toolStrip, ResourceManager resourceManager)
        {
            var items = toolStrip.Items;
            foreach (ToolStripItem item in items)
            {
                
                item.Text = resourceManager.GetString(nameof(item) + ControlConstants.TextPropertyName);
            }
        }
    }
}
