using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace jmILRL.common
{
    public class Tools
    {
        /// <summary>
        /// 修改AppSettings中配置
        /// </summary>
        /// <param name="key">key值</param>
        /// <param name="value">相应值</param>
        public static bool SetConfigValue(string key, string value)
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                if (config.AppSettings.Settings[key] != null)
                    config.AppSettings.Settings[key].Value = value;
                else
                    config.AppSettings.Settings.Add(key, value);
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static string killdB(string dB)
        {
            return dB.Replace("dB", "").Replace("-", "");
        }

        public static float getMax(float[] input) {
            float max = input[0];
            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] > max)
                    max = input[i];
            }
            return max;
        }

        public static float getMin(float[] input)
        {
            float min = input[0];
            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] < min)
                    min = input[i];
            }
            return min;
        }
    }
}
