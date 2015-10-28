using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml;

namespace MH4U_Database.Controls
{
    /// <summary>
    /// Converts an integer to Visibility where 0 is considered not visible.
    /// </summary>
    class IntegerVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string s)
        {
            if (value == null)
                return Visibility.Collapsed;
            else if(value is int)
            {
                int v = (int)value;
                if (v == 0)
                    return Visibility.Collapsed;
                return Visibility.Visible;
            }
            else if(value is bool)
            {
                bool v = (bool)value;
                if (v)
                    return Visibility.Visible;
                return Visibility.Collapsed;
            }
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string s)
        {
            throw new NotImplementedException();
        }
    }
}
