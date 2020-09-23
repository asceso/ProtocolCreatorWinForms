using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace ProtocolCreator.Translate
{
    internal static class TextTranslator
    {
        /// <summary>
        /// Перевод текста
        /// </summary>
        /// <param name="text">Текст который нужно перевести</param>
        /// <returns>перевод в стиле PascalCasing (пример: грустный мальчик - SadBoy)</returns>
        internal static string TranslateToEng(string text)
        {
            WriteInput(text);
            RunTranslate();
            return ReadOutput();
        }
        #region Translate methods
        private static void WriteInput(string text)
        {
            using (StreamWriter writer = new StreamWriter(Environment.CurrentDirectory + "\\Translate\\words_input.txt"))
            {
                writer.Write(text);
            }
        }
        private static void RunTranslate()
        {
            var info = new ProcessStartInfo
            {
                FileName = Environment.CurrentDirectory + "\\Translate\\run_translate.bat",
                WindowStyle = ProcessWindowStyle.Hidden
            };
            Process.Start(info).WaitForExit();
        }
        private static string ReadOutput()
        {
            string translated;
            using (StreamReader reader = new StreamReader(Environment.CurrentDirectory + "\\Translate\\words_output.txt"))
            {
                translated = reader.ReadToEnd().Trim();
            }
            string[] words = translated.Split(' ');
            StringBuilder result = new StringBuilder();
            foreach (string item in words)
            {
                result.Append(FirstUpper(item));
            }
            return result.ToString();
        }
        private static string FirstUpper(string word)
        {
            if (word.Length.Equals(0))
                return string.Empty;
            char[] letters = word.ToCharArray();
            letters[0] = char.ToUpper(letters[0]);
            return new string(letters);
        }
        #endregion
    }
}
