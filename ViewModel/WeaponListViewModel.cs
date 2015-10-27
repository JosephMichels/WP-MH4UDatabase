using MH4U_Database.Database;
using System.Collections.Generic;

namespace MH4U_Database.ViewModel
{
    class WeaponListViewModel:BaseViewModel
    {
        string _weaponType;
        public string WeaponType {
            get { return _weaponType; }
            set
            {
                _weaponType = value;
                OnPropertyChanged("WeaponType");
            }
        }

        List<WeaponTreeEntry> _weaponTree;
        public List<WeaponTreeEntry> WeaponTree
        {
            get { return _weaponTree; }
            set
            {
                _weaponTree = value;
                OnPropertyChanged("WeaponTree");
            }
        }

        public WeaponListViewModel(string weaponType)
        {
            _weaponType = weaponType;
            LoadData();
        }

        public async void LoadData()
        {
            var weapons = await MHDatabaseHelper.GetWeaponsByType(WeaponType);
            WeaponTree = WeaponTreeEntry.GenerateTree(weapons);
        }


    }
}
