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
            else
            {
                int v = (int)value;
                if (v == 0)
                    return Visibility.Collapsed;
                return Visibility.Visible;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string s)
        {
            throw new NotImplementedException();
        }
    }
}
