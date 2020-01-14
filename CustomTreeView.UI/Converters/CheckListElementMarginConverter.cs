using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using CustomTreeView.UI.Model;

namespace CustomTreeView.UI.Converters
{
    class CheckListElementMarginConverter  :IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is CheckListElement checkListElement)
            {
                return new Thickness(97+checkListElement.Level*17, 0,17,0);
            }
            return new Thickness();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
