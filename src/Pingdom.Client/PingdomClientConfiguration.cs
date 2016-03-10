namespace PingdomClient
{
    using System.Configuration;
    using System.Linq;

    public class PingdomClientConfiguration
    {
        public string AppKey { get; private set; }

        public string BaseAddress { get; private set; }

        public string UserName { get; private set; }

        public string Password { get; private set; }

        public string AccountEmail { get; private set; }

        public PingdomClientConfiguration()
        {
            AppKey = GetConfigurationKey("AppKey");
            BaseAddress = GetConfigurationKey("BaseUrl");
            UserName = GetConfigurationKey("UserName");
            Password = GetConfigurationKey("Password");
            AccountEmail = GetConfigurationKey("AccountEmail");
        }
        
        public PingdomClientConfiguration(string appKey, string baseAddress, string userName, string password)
            :this(appKey, baseAddress, userName, password, null) { }
        
        public PingdomClientConfiguration(string appKey, string baseAddress, string userName, string password, string accountEmail)
        {
            AppKey = appKey;
            BaseAddress = baseAddress;
            UserName = userName;
            Password = password;
            AccountEmail = accountEmail;
        }

        private static string GetConfigurationKey(string key)
        {
            var fullKey = string.Format("pingdom:{0}", key);
            if (ConfigurationManager.AppSettings.AllKeys.Contains(fullKey))
                return ConfigurationManager.AppSettings[fullKey];
            else
                return string.Empty;
        }
    }
}
