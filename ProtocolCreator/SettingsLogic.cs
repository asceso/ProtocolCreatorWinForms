using Newtonsoft.Json;
using ProtocolCreator.Models;
using System;
using System.IO;
using System.Windows.Forms;

namespace ProtocolCreator
{
    internal static class SettingsLogic
    {
        /// <summary>
        /// Считывание текущих настроек
        /// </summary>
        /// <param name="settingFilePath">Путь к файлу с настройками</param>
        /// <returns>Возвращает модель типа SettingsModel</returns>
        internal static SettingsModel GetConfig(string settingFilePath)
        {
            try
            {
                string buffer = string.Empty;
                using (StreamReader reader = new StreamReader(settingFilePath))
                {
                    buffer = reader.ReadToEnd();
                }
                return JsonConvert.DeserializeObject<SettingsModel>(buffer);
            }
            catch (Exception)
            {
                MessageBox.Show("При загрузке настроек произошла ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new SettingsModel();
            }
        }
        /// <summary>
        /// Запись файла настроек
        /// </summary>
        /// <param name="settings">Модель настроек которую нужно записать</param>
        /// <param name="settingFilePath">Путь к файлу с настройками</param>
        /// <returns>False = если была ошибка, True - сохранение успешно</returns>
        internal static bool SetConfig(SettingsModel settings, string settingFilePath)
        {
            try
            {
                string JsonSettings = JsonConvert.SerializeObject(settings, Formatting.Indented);
                using (StreamWriter writer = new StreamWriter(settingFilePath))
                {
                    writer.Write(JsonSettings);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("При сохранении настроек произошла ошибка!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            MessageBox.Show("Сохранение прошло успешно.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }
    }
}
