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
    class WeaponFamiltyTemplateSelector : DataTemplateSelector
    {
        public DataTemplate AncestorWeaponTemplate { get; set; }
        public DataTemplate CurrentWeaponTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object item)
        {
            Weapon w = (Weapon)item;
            if (w.tree_depth == -1)     //Part of hack. tree_depth of -1 indicates current weapon
                return CurrentWeaponTemplate;
            return AncestorWeaponTemplate;
        }
    }
}
