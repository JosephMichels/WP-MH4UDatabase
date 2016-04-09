using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Windows.UI;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace MH4U_Database.Controls
{
    class RarityColorConverter : IValueConverter
    {
        static Color[] colors ={
                                   Colors.Gray,
                                   Colors.Purple,
                                   Colors.Yellow,
                                   Colors.Pink,
                                   Colors.LimeGreen,
                                   Colors.Blue,
                                   Colors.Red,
                                   Colors.LightBlue,
                                   Colors.Orange,
                                   Colors.HotPink
                              };


        public object Convert(object value, Type targetType, object parameter, string s)
        {
            int rarity = (int)value;
            Brush b = new SolidColorBrush(colors[rarity - 1]);
            return b;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string s)
        {
            throw new NotImplementedException();
        }
    }
}
