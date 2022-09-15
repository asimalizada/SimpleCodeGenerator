using Generator.Classes;
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

        public static void BuildAppSettings(AppSettings settings)
        {
            settings.Entity = ConfigurationHelper.GetAppSetting("entity");
            settings.ProjectPath = ConfigurationHelper.GetAppSetting("projectPath");
            settings.DataAccessPath = ConfigurationHelper.GetAppSetting("dataAccessPath");
            settings.DataAccessNamespace = ConfigurationHelper.GetAppSetting("dataAccessNamespace");
            settings.BusinessPath = ConfigurationHelper.GetAppSetting("businessPath");
            settings.BusinessNamespace = ConfigurationHelper.GetAppSetting("businessNamespace");
            settings.Context = ConfigurationHelper.GetAppSetting("context");
            settings.DataAccessAbstract = ConfigurationHelper.GetAppSetting("dataAccessAbstract");
            settings.DataAccessConcrete = ConfigurationHelper.GetAppSetting("dataAccessConcrete");
            settings.BusinessAbstract = ConfigurationHelper.GetAppSetting("businessAbstract");
            settings.BusinessConcrete = ConfigurationHelper.GetAppSetting("businessConcrete");
        }

        public static void ReBuildAppSettings(AppSettings settings)
        {
            ConfigurationHelper.SetSetting("context", settings.Context);
            ConfigurationHelper.SetSetting("entity", settings.Entity);
            ConfigurationHelper.SetSetting("projectPath", settings.ProjectPath);
            ConfigurationHelper.SetSetting("dataAccessPath", settings.DataAccessPath);
            ConfigurationHelper.SetSetting("dataAccessNamespace", settings.DataAccessNamespace);
            ConfigurationHelper.SetSetting("businessPath", settings.BusinessPath);
            ConfigurationHelper.SetSetting("businessNamespace", settings.BusinessNamespace);
            ConfigurationHelper.SetSetting("dataAccessAbstract", settings.DataAccessAbstract);
            ConfigurationHelper.SetSetting("dataAccessConcrete", settings.DataAccessConcrete);
            ConfigurationHelper.SetSetting("businessAbstract", settings.BusinessAbstract);
            ConfigurationHelper.SetSetting("businessConcrete", settings.BusinessConcrete);
        }

    }
}
