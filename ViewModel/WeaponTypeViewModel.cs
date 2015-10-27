using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH4U_Database.ViewModel
{
    class WeaponTypeViewModel : BaseViewModel
    {

        public class WeaponTypeObject
        {
            public string Name { get; set; }
            public string Icon { get; set; }

            public WeaponTypeObject(string n)
            {
                Name = n;
                Icon = "/Assets/icons_items/"+n.Replace(' ', '_').ToLower() + "1.png";
            }
        }

        List<WeaponTypeObject> _itemTypes;
        public List<WeaponTypeObject> WeaponTypes
        {
            get { return _itemTypes; }
            set
            {
                _itemTypes = value;
                OnPropertyChanged("WeaponTypes");
            }
        }

        public WeaponTypeViewModel()
        {
            var items = new List<WeaponTypeObject>();
            items.AddRange(new WeaponTypeObject[]
            {
                new WeaponTypeObject("Great Sword"),
                new WeaponTypeObject("Long Sword"),
                new WeaponTypeObject("Sword and Shield"),
                new WeaponTypeObject("Dual Blades"),
                new WeaponTypeObject("Hammer"),
                new WeaponTypeObject("Lance"),
                new WeaponTypeObject("Gunlance"),
                new WeaponTypeObject("Switch Axe"),
                new WeaponTypeObject("Charge Blade"),
                new WeaponTypeObject("Insect Glaive"),
                new WeaponTypeObject("Light Bowgun"),
                new WeaponTypeObject("Heavy Bowgun"),
                new WeaponTypeObject("Bow")
            });
            WeaponTypes = items;
        }
    }
}
