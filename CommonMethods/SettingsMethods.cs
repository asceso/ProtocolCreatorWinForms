using CommonModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonMethods
{
    public static class SettingsMethods
    {
        public static bool SaveSettingsToJson(SettingsModel model)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(Environment.CurrentDirectory + "\\ApplicationSettings.json"))
                {
                    string jsonSettings = JsonConvert.SerializeObject(model, Formatting.Indented);
                    writer.Write(jsonSettings);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static SettingsModel ReadSettingsFromJson()
        {
            try
            {
                using (StreamReader reader = new StreamReader(Environment.CurrentDirectory + "\\ApplicationSettings.json"))
                {
                    string fileSettings = reader.ReadToEnd();
                    return JsonConvert.DeserializeObject<SettingsModel>(fileSettings);
                }
            }
            catch (Exception)
            { 
                return new SettingsModel();
            }
        }
    }
}
