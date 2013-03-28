using System.Collections.Generic;

namespace iUPB.Common
{
    internal class ConfigProvider
    {
        private Dictionary<string, string> settings;

        private static ConfigProvider instance;

        private ConfigProvider()
        {
            settings = new Dictionary<string, string>()
            {
                { "root_url", "http://www.i-upb.de/" },
                { "restaurants_url", "http://beta.i-upb.de/api/v1/restaurants" },
                { "menus_url_prefix", "http://beta.i-upb.de/api/v1/menus/" }
            };
        }

        public static ConfigProvider Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ConfigProvider();
                }
                return instance;
            }
        }

        public string Get(string key, string fallback = null)
        {
            string value;
            if (settings.TryGetValue(key, out value))
            {
                return value;
            }
            else
            {
                if (fallback != null)
                {
                    return fallback;
                }
                else
                {
                    throw new KeyNotFoundException("setting not present: " + key);
                }
            }
        }
    }
}