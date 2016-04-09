using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace MH4U_Database.Converters
{
    class NoteImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string r = value.ToString();
            if (r.Equals("W"))
                return "/Assets/icons_armor/Note.white.png";
            else if(r.Equals("P"))
                return "/Assets/icons_armor/Note.purple.png";
            else if(r.Equals("B"))
                return "/Assets/icons_armor/Note.blue.png";
            else if(r.Equals("R"))
                return "/Assets/icons_armor/Note.red.png";
            else if(r.Equals("Y"))
                return "/Assets/icons_armor/Note.yellow.png";
            else if(r.Equals("O"))
                return "/Assets/icons_armor/Note.orange.png";
            else if(r.Equals("G"))
                return "/Assets/icons_armor/Note.green.png";
            else if(r.Equals("C"))
                return "/Assets/icons_armor/Note.aqua.png";
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
