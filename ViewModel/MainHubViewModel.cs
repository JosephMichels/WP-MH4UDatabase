using MH4U_Database.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH4U_Database.ViewModel
{
    public class MainHubViewModel: BaseViewModel
    {
        List<Monster> _monsters;
        public List<Monster> Monsters { get
            {
                return _monsters;
            }
            set
            {
                _monsters = value;
                OnPropertyChanged("Monsters");
                Debug.WriteLine("Monsters Loaded");
            }
        }

        List<Item> _allItems;
        List<Item> AllItems
        {
            get { return _allItems; }
            set
            {
                _allItems = value;
                Items = _allItems;
            }
        }

        List<Item> _items;
        public List<Item> Items
        {
            get
            {
                if (_search == null || _search.Length == 0)
                    return _allItems;
                else
                    return _items;
            }
            set
            {
                _items = value;
                OnPropertyChanged("Items");
                _stopwatch.Stop();
                Debug.WriteLine("Items Loaded - "+_stopwatch.ElapsedMilliseconds);
            }
        }

        string _search;
        public String Search
        {
            get { return _search; }
            set
            {
                //Refresh the items list
                _search = value;
                OnPropertyChanged("Search");
                DoItemSearch();
            }
        }

        Stopwatch _stopwatch;

        public MainHubViewModel()
        {
            new MHDatabaseHelper();
        }

        public async void LoadData()
        {
            if(Monsters == null)
                Monsters = await MHDatabaseHelper.GetAllLargeMonsters();
            if (AllItems == null)
            {
                _stopwatch = new Stopwatch();
                _stopwatch.Start();
                AllItems = await MHDatabaseHelper.GetAllItems();
            }
        }

        private void DoItemSearch()
        {
            if (Search.Length == 0)
                Items = _allItems;
            else
                Items = _allItems.Where<Item>((i) => i.name.IndexOf(Search,StringComparison.CurrentCultureIgnoreCase)>=0).ToList<Item>();
        }
    }
}
