using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Windows.UI.Xaml.Data;

namespace MH4U_Database.Controls
{
    /// <summary>
    /// Converts an element string such as 'ice' to the appropriate image path
    /// </summary>
    class ElementImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string s)
        {
            if (value == null)
                return null;
            if (value.ToString().Length == 0)
                return null;
            return "/Assets/icons_monster_info/" + value + ".png";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string s)
        {
            throw new NotImplementedException();
        }
    }
}
