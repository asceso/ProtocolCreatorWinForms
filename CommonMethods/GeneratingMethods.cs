using CommonModels.ProtocolElementsModels.InheritModels;
using System;
using System.Windows.Controls;

namespace CommonMethods
{
    public class GeneratingMethods
    {
        #region enums
        private enum XMLElements
        {
            StartBlock, EndBlock, EndBlockNoBracket, CreateType,
            TextBox, TextBlock, Date, CheckBox, ComboBox, NumericBox,
            StackPanel, StackPanelStart, StackPanelEnd
        }
        private static string[] orientations = Enum.GetNames(typeof(Orientation));
        #endregion enums

        /// <summary>
        /// Создать XML элемент
        /// </summary>
        /// <param name="key">Ключ</param>
        /// <param name="value">Значение</param>
        /// <param name="ifNullAddValue">Если поле Null добавлять Пару</param>
        /// <returns>Строка из XML тега</returns>
        private static string CreateXMLElement(string key, object value = null, bool ifNullAddValue = true, int level = 0)
        {
            if (key.Equals(nameof(XMLElements.StartBlock)))
            {
                string tmp = string.Empty;
                for (int i = 0; i < (level + 1) * 2; i++)
                { tmp += " "; }
                return tmp + "<";
            }
            if (key.Equals(nameof(XMLElements.EndBlock)))
                return " />";
            if (key.Equals(nameof(XMLElements.EndBlockNoBracket)))
                return " >";
            if (key.Equals(nameof(XMLElements.CreateType)))
                return value + $" itemType=\"{value}\"";

            string temp = $" {key}=\"";

            if (value is bool)
                return temp += value.ToString().ToLower() + "\"";
            if (value is string)
            {
                if (string.IsNullOrEmpty((string)value))
                    if (ifNullAddValue)
                        return temp += value.ToString() + "\"";
                    else
                        return string.Empty;

                CheckInvalidSymbols(ref value);

                return temp += value + "\"";
            }
            if (value is int)
            {
                if (ifNullAddValue)
                    return $" {key}=\"{value}\"";
                else
                    return string.Empty;
            }
            if (value is float)
            {
                if (ifNullAddValue)
                { 
                    if (key.Equals("Step"))
                        return $" {key}=\"{String.Format("{0:N1}", value).Replace(',','.')}\"";
                    else
                        return $" {key}=\"{String.Format("{0:N1}", value)}\"";
                }
                else
                    return string.Empty;
            }
            return "Ошибка";
        }
        private static void CheckInvalidSymbols(ref object value)
        {
            value = value.ToString().Replace("\r\n", "\\r\\n");
            while (value.ToString().Contains("\""))
            {
                value = value.ToString().Replace("\"", "'");
            }
            while (value.ToString().Contains(">"))
            {
                value = value.ToString().Replace(">", "&#707;");
            }
            while (value.ToString().Contains("<"))
            {
                value = value.ToString().Replace("<", "&#706;");
            }
        }
        public static string CreateTextBox(TextBoxModel model, int level=0)
        {
            string buffer = string.Empty;
            buffer += CreateXMLElement(nameof(XMLElements.StartBlock), level: level);
            buffer += CreateXMLElement(nameof(XMLElements.CreateType), nameof(XMLElements.TextBox));
            buffer += CreateXMLElement("Id", model.ID);
            buffer += CreateXMLElement("Name", model.Name, false);
            buffer += CreateXMLElement("Value", model.Value);
            buffer += CreateXMLElement("IsEnabled", model.IsEnabled);
            buffer += CreateXMLElement("IsStretch", model.IsStretch);
            buffer += CreateXMLElement("IsVisible", model.IsVisible);
            buffer += CreateXMLElement("IsLabelVisible", model.IsLabelVisible);
            buffer += CreateXMLElement("IsBoldLabel", model.IsBoldLabel);
            buffer += CreateXMLElement("IsConclusion", model.IsConclusion);
            buffer += CreateXMLElement("Lines", model.Lines, !model.Lines.Equals(0));
            buffer += CreateXMLElement(nameof(XMLElements.EndBlock));
            return buffer;
        }
        public static string CreateTextBlock(TextBlockModel model, int level = 0)
        {
            string buffer = string.Empty;
            buffer += CreateXMLElement(nameof(XMLElements.StartBlock), level: level);
            buffer += CreateXMLElement(nameof(XMLElements.CreateType), nameof(XMLElements.TextBlock));
            buffer += CreateXMLElement("Id", model.ID);
            buffer += CreateXMLElement("Name", model.Name, false);
            buffer += CreateXMLElement("Value", model.Value);
            buffer += CreateXMLElement("IsEnabled", model.IsEnabled);
            buffer += CreateXMLElement("IsStretch", model.IsStretch);
            buffer += CreateXMLElement("IsVisible", model.IsVisible);
            buffer += CreateXMLElement("IsBold", model.IsBold);
            buffer += CreateXMLElement("MinWidth", model.MinWidth, !model.MinWidth.Equals(0));
            buffer += CreateXMLElement(nameof(XMLElements.EndBlock));
            return buffer;
        }
        public static string CreateDateBlock(DateModel model, int level = 0)
        {
            string buffer = string.Empty;
            buffer += CreateXMLElement(nameof(XMLElements.StartBlock), level: level);
            buffer += CreateXMLElement(nameof(XMLElements.CreateType), nameof(XMLElements.Date));
            buffer += CreateXMLElement("Id", model.ID);
            buffer += CreateXMLElement("Name", model.Name, false);
            buffer += CreateXMLElement("IsEnabled", model.IsEnabled);
            buffer += CreateXMLElement("IsVisible", model.IsVisible);
            buffer += CreateXMLElement("IsLabelVisible", model.IsLabelVisible);
            buffer += CreateXMLElement(nameof(XMLElements.EndBlock));
            return buffer;
        }
        public static string CreateCheckBoxModel(CheckBoxModel model, int level = 0)
        {
            string buffer = string.Empty;
            buffer += CreateXMLElement(nameof(XMLElements.StartBlock), level: level);
            buffer += CreateXMLElement(nameof(XMLElements.CreateType), nameof(XMLElements.CheckBox));
            buffer += CreateXMLElement("Id", model.ID);
            buffer += CreateXMLElement("Name", model.Name, false);
            buffer += CreateXMLElement("TextTrue", model.TextTrue);
            buffer += CreateXMLElement("TextFalse", model.TextFalse);
            buffer += CreateXMLElement("IsEnabled", model.IsEnabled);
            buffer += CreateXMLElement("IsVisible", model.IsVisible);
            buffer += CreateXMLElement("IsLabelVisible", model.IsLabelVisible);
            buffer += CreateXMLElement("MinWidth", model.MinWidth, !model.MinWidth.Equals(0));
            buffer += CreateXMLElement(nameof(XMLElements.EndBlock));
            return buffer;
        }
        public static string CreateComboBoxModel(ComboBoxModel model, int level = 0)
        {
            string buffer = string.Empty;
            buffer += CreateXMLElement(nameof(XMLElements.StartBlock), level: level);
            buffer += CreateXMLElement(nameof(XMLElements.CreateType), nameof(XMLElements.ComboBox));
            buffer += CreateXMLElement("Id", model.ID);
            buffer += CreateXMLElement("Name", model.Name, false);
            buffer += CreateXMLElement("MinWidth", model.MinWidth, !model.MinWidth.Equals(0));
            buffer += CreateXMLElement("IsEnabled", model.IsEnabled);
            buffer += CreateXMLElement("IsVisible", model.IsVisible);
            buffer += CreateXMLElement("IsLabelVisible", model.IsLabelVisible);
            buffer += CreateXMLElement("IsTextEditable", model.IsTextEditable);
            buffer += CreateXMLElement("IsConclusionTemplate", model.IsConclusionTemplate);
            buffer += CreateXMLElement("IsSelectedFromNetrika", model.IsSelectedFromNetrika);
            buffer += CreateXMLElement("IsUseNetrika", model.IsUseNetrika);
            buffer += CreateXMLElement("Value", model.Value);
            string tmpCollection = model.Value;
            foreach (string item in model.Values)
            {
                tmpCollection += $"|{item}";
            }
            if (tmpCollection.StartsWith("|")) tmpCollection = tmpCollection.Remove(0, 1);
            buffer += CreateXMLElement("Values", tmpCollection);
            buffer += CreateXMLElement(nameof(XMLElements.EndBlock));
            return buffer;
        }
        public static string CreateNumericModel(NumericModel model, int level = 0)
        {
            string buffer = string.Empty;
            buffer += CreateXMLElement(nameof(XMLElements.StartBlock), level: level);
            buffer += CreateXMLElement(nameof(XMLElements.CreateType), nameof(XMLElements.NumericBox));
            buffer += CreateXMLElement("Id", model.ID);
            buffer += CreateXMLElement("Name", model.Name, false);
            buffer += CreateXMLElement("IsEnabled", model.IsEnabled);
            buffer += CreateXMLElement("IsVisible", model.IsVisible);
            buffer += CreateXMLElement("IsLabelVisible", model.IsLabelVisible);
            buffer += CreateXMLElement("Value", model.Value);
            buffer += CreateXMLElement("Step", model.Step);
            buffer += CreateXMLElement("FormatString", model.FormatString);
            buffer += CreateXMLElement("MinWidth", model.MinWidth, !model.MinWidth.Equals(0));
            buffer += CreateXMLElement(nameof(XMLElements.EndBlock));
            return buffer;
        }
        public static string CreateStackPanelStart(int stackNumber, int orientation, int level)
        {
            string buffer = string.Empty;
            buffer += CreateXMLElement(nameof(XMLElements.StartBlock), level: level);
            buffer += CreateXMLElement(nameof(XMLElements.CreateType), nameof(XMLElements.StackPanel));
            buffer += stackNumber.Equals(-1) ? CreateXMLElement("Id", $"StackHeader") : CreateXMLElement("Id", $"Stack{stackNumber}");
            buffer += CreateXMLElement("Name", string.Empty);
            buffer += CreateXMLElement("IsEnabled", true);
            buffer += CreateXMLElement("IsVisible", false);
            buffer += CreateXMLElement("IsLabelVisible", false);
            buffer += CreateXMLElement("Orientation", orientations[orientation]);
            buffer += CreateXMLElement(nameof(XMLElements.EndBlockNoBracket));
            return buffer;
        }
        public static string CreateStackPanelEnd(int level)
        {
            string tmp = string.Empty;
            for (int i = 0; i < (level + 1) * 2; i++)
            { tmp += " "; }
            return tmp + "</StackPanel>";
        }
    }
}
