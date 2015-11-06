using MH4U_Database.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH4U_Database.ViewModel
{
    class WeaponDetailsViewModel : BaseViewModel
    {

        Weapon _weapon;
        public Weapon Weapon
        {
            get { return _weapon; }
            set {
                _weapon = value;
                OnPropertyChanged("Weapon");
            }
        }

        List<Component> _components;
        public List<Component> Components
        {
            get { return _components; }
            set
            {
                _components = value;
                OnPropertyChanged("Components");
            }
        }

        List<Weapon> _weaponFamily;
        public List<Weapon> WeaponFamily
        {
            get { return _weaponFamily; }
            set
            {
                _weaponFamily = value;
                OnPropertyChanged("WeaponFamily");
            }
        }

        public WeaponDetailsViewModel(int id)
        {
            LoadData(id);
        }

        async void LoadData(int id)
        {
            if (Weapon == null)
                Weapon = await MHDatabaseHelper.GetWeapon(id);
            if (Components == null)
                Components = await MHDatabaseHelper.GetComponentsForItem(id);
            if (WeaponFamily == null)
            {
                List<Weapon> w = MHDatabaseHelper.GetWeaponParents(id);
                List<Weapon> upgrades = await MHDatabaseHelper.GetWeaponChildren(id);
                foreach (Weapon wep in upgrades) wep.final = 1;
                w.AddRange(upgrades);
                if (upgrades.Count == 0) w[w.Count - 1].final = 1;
                WeaponFamily = w;
            }
        }

    }
}
