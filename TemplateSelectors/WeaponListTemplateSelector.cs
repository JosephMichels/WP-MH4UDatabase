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
        public DataTemplate HuntingHornTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object item)
        {
            if (item == null) return null;

            Weapon w = null;

            if (item is Weapon)
                w = (Weapon)item;

            if (item is WeaponTreeEntry)
                w = ((WeaponTreeEntry)item).Weapon;

            if (w.wtype.Equals("Bow"))
                return BowTemplate;
            else if (w.wtype.Equals("Light Bowgun") || w.wtype.Equals("Heavy Bowgun"))
                return BowGunTemplate;
            else if (w.wtype.Equals("Hunting Horn"))
                return HuntingHornTemplate;
            return BladeTemplate;
        }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            return SelectTemplateCore(item);
        }
    }
}
