
using Microsoft.Extensions.Configuration;

namespace UpdateInventoryMagentoUI
{
    internal class Configuration
    {
        private static IConfiguration _config;
        public string userName;
        public string password;
        public string url;

        public void InitializeConfiguration()
        {

            /* Build the path to the appsettings.json file */
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

            _config = builder.Build();

            userName = _config.GetValue<string>("userName");
            password = _config.GetValue<string>("password");
            url = _config.GetValue<string>("prodUrl");
        }
    }
}
