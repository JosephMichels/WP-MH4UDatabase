using MH4U_Database.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH4U_Database.ViewModel
{
    class ArmorListViewModel : BaseViewModel
    {

        //Class used to house the grouping
        public class ArmorTypeGroup : ObservableCollection<Armor>
        {
            public ArmorTypeGroup(IEnumerable<Armor> items) : base(items)
            {

            }

            public string Slot { get; set; }
        }

        List<ArmorTypeGroup> _bladeArmorGroups;
        public List<ArmorTypeGroup> BladeArmorGroups
        {
            get { return _bladeArmorGroups; }
            set
            {
                _bladeArmorGroups = value;
                OnPropertyChanged("BladeArmorGroups");
            }
        }

        List<ArmorTypeGroup> _gunnerArmorGroups;
        public List<ArmorTypeGroup> GunnerArmorGroups
        {
            get { return _gunnerArmorGroups; }
            set
            {
                _gunnerArmorGroups = value;
                OnPropertyChanged("GunnerArmorGroups");
            }
        }

        List<ArmorTypeGroup> _bothArmorGroups;
        public List<ArmorTypeGroup> BothArmorGroups
        {
            get { return _bothArmorGroups; }
            set
            {
                _bothArmorGroups = value;
                OnPropertyChanged("BothArmorGroups");
            }
        }


        public ArmorListViewModel()
        {
            LoadData();
        }

        async void LoadData()
        {
            //Crazy LINQ queries to setup grouping
            if (BladeArmorGroups == null)
                BladeArmorGroups = (from item in (await MHDatabaseHelper.GetArmorForHunterType("Blade"))
                                    group item by item.slot into armorGroup
                                    select new ArmorTypeGroup(armorGroup) { Slot = armorGroup.Key }).ToList();
            if (GunnerArmorGroups == null)
                GunnerArmorGroups = (from item in (await MHDatabaseHelper.GetArmorForHunterType("Gunner"))
                                    group item by item.slot into armorGroup
                                    select new ArmorTypeGroup(armorGroup) { Slot = armorGroup.Key }).ToList();
            if (BothArmorGroups == null)
                BothArmorGroups = (from item in (await MHDatabaseHelper.GetArmorForHunterType("Both"))
                                    group item by item.slot into armorGroup
                                    select new ArmorTypeGroup(armorGroup) { Slot = armorGroup.Key }).ToList();
        }
    }
}
