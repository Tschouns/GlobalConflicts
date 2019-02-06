
using System.Configuration;

namespace ConflictCatalogImport
{
    public static class Config
    {
        public static string FileName => ReadAppSetting("fileName");
        public static string ConnectionString => ReadAppSetting("connectionString");

        private static string ReadAppSetting(string key)
        {
            var value = ConfigurationManager.AppSettings[key];
            if (value == null)
            {
                throw new ConfigurationErrorsException($"The app settings entry with key '{key}' is missing.");
            }

            return value;
        }
    }
}
