using MH4U_Database.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH4U_Database.ViewModel
{
    class MonsterListViewModel :BaseViewModel
    {
        public List<Monster> _monsters;
        public List<Monster> Monsters { get { return _monsters; }
            set
            {
                _monsters = value;
                OnPropertyChanged("Monsters");
            }
        }

        public List<Monster> _smallMonsters;
        public List<Monster> SmallMonsters
        {
            get { return _smallMonsters; }
            set
            {
                _smallMonsters = value;
                OnPropertyChanged("SmallMonsters");
            }
        }

        public MonsterListViewModel()
        {
            LoadData();
        }

        async void LoadData()
        {
            if(Monsters == null)
                Monsters = await MHDatabaseHelper.GetAllLargeMonsters();
            if (SmallMonsters == null)
                SmallMonsters = await MHDatabaseHelper.GetAllSmallMonsters();
        }
    }
}
