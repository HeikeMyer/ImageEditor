using System.Configuration;
using ImageEditor.Constants;

namespace ImageEditor.Operations
{
    class ConfigurationOperation
    {
        public static void UpdateAppSettings(string key, string value)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings[key].Value = value;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(ConfigurationConstants.AppSettingsSection);
        }
    }
}
