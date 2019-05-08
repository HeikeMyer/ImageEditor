using System;
using System.Globalization;
using System.Threading;
using System.Resources;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;
using ImageEditor.Constants;

namespace ImageEditor
{
    public static class ReloadTextFormExtension
    {
        public static void ReloadText<T>(IEnumerable<T> items, ResourceManager resourceManager) where T: ToolStripItem
        {
            foreach (var item in items)
            {
                item.Text = resourceManager.GetString(item.Name + ControlConstants.TextPropertyName);
            }
        }
        
        public static IEnumerable<ToolStripMenuItem> GetUpperLevelToolStripMenuItemCollection(this IEnumerable<ToolStripDropDownButton> toolStripDropDownButtons)
        {
            return toolStripDropDownButtons.SelectMany(dropDownButton => dropDownButton.DropDownItems.Cast<ToolStripMenuItem>());
        }

        public static IEnumerable<ToolStripMenuItem> GetToolStripMenuItemCollection(IEnumerable<ToolStripDropDownButton> toolStripDropDownButtons)
        {
            var collection = new List<ToolStripMenuItem>();
            var bfsQueue = new List<ToolStripMenuItem>(toolStripDropDownButtons.GetUpperLevelToolStripMenuItemCollection());

            while (bfsQueue.Count > 0)
            {
                var current = bfsQueue[0];
                collection.Add(current);
                bfsQueue.RemoveAt(0);
                bfsQueue.AddRange(current.DropDownItems.Cast<ToolStripMenuItem>());
            }

            return collection;
        }

        public static void ReloadText(ToolStrip toolStrip, ResourceManager resourceManager)
        {
            var items = toolStrip.Items.OfType<ToolStripDropDownButton>();
            ReloadText(items, resourceManager);
            var innerItems = GetToolStripMenuItemCollection(items);
            ReloadText(innerItems, resourceManager);
        }

        public static void ReloadText(Form form, ResourceManager resourceManager)
        {
            foreach(Control control in form.Controls)
            {
                if (control is ToolStrip toolStrip)
                {
                    ReloadText(toolStrip, resourceManager);
                }
                else
                {
                    var resourseString = resourceManager.GetString(control.Name + ControlConstants.TextPropertyName);
                    if (!string.IsNullOrEmpty(resourseString))
                    {
                        control.Text = resourseString;
                    }
                }
            }
        }

        public static void ReloadText(this Form form, Type type, string cultureCode)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureCode);
            ResourceManager resourceManager = new ResourceManager(type);

            form.Text = resourceManager.GetString(nameof(ControlConstants.FormTextResourceString));
            ReloadText(form, resourceManager);
        }
    }
}
