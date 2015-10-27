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
    /// Converts a tree_depth integer to a acceptable margin. Used for displaying weapon trees.
    /// </summary>
    class MarginConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string s)
        {
            int indent = (int)value;
            Thickness margin = new Thickness((indent-1) * 4, 0, 0, 0);
            return margin;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string s)
        {
            throw new NotImplementedException();
        }
    }
}
