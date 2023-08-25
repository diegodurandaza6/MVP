using PayPal.Api;
using System.Collections.Generic;

namespace Web.Model.Paypal
{
    public class Configuration
    {
        public readonly static string ClientId;
        public readonly static string ClientSecret; 
        static Configuration()
        {
                var config = GetConfig();
                ClientId =   System.Configuration.ConfigurationManager.AppSettings["client_Id"];// config["clientId"];
                ClientSecret =   System.Configuration.ConfigurationManager.AppSettings["client_Secret"];// config["clientSecret"]; 
        }

        // Create the configuration map that contains mode and other optional configuration details.
        public static Dictionary<string, string> GetConfig()
        {
            return PayPal.Api.ConfigManager.Instance.GetProperties();
        }

        // Create accessToken
        private static string GetAccessToken()
        {               
            string accessToken = new OAuthTokenCredential(ClientId, ClientSecret, GetConfig()).GetAccessToken();
            return accessToken;
        }

        // Returns APIContext object
        public static APIContext GetAPIContext()
        { 
            APIContext apiContext = new APIContext(GetAccessToken());
            apiContext.Config = GetConfig();
            apiContext.Config.Add("connectionTimeout", "120000"); 

            return apiContext;
        }
    }
}
