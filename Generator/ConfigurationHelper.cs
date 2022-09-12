using System.Configuration;

namespace Generator
{
    public static class ConfigurationHelper
    {
        private static readonly Configuration _configuration;

        static ConfigurationHelper()
        {
            _configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        }

        public static string GetAppSetting(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        public static void SetSetting(string key, string value)
        {
            _configuration.AppSettings.Settings[key].Value = value;
            _configuration.Save(ConfigurationSaveMode.Full, true);
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
