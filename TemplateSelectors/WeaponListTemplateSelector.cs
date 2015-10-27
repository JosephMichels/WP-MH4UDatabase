using MH4U_Database.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MH4U_Database.TemplateSelectors
{
    class WeaponListTemplateSelector : DataTemplateSelector
    {
        public DataTemplate BladeTemplate { get; set; }
        public DataTemplate BowTemplate { get; set; }
        public DataTemplate BowGunTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object item)
        {
            Weapon w = (Weapon)item;
            if (w.wtype.Equals("Bow"))
                return BowTemplate;
            else if (w.wtype.Equals("Light Bowgun") || w.wtype.Equals("Heavy Bowgun"))
                return BowGunTemplate;
            return BladeTemplate;
        }
    }
}
