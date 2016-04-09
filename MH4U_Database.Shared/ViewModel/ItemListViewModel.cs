using MH4U_Database.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH4U_Database.ViewModel
{
    class ItemListViewModel : BaseViewModel
    {
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
        public List<Item> Items {
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
            }
        }

        string _search;
        public string Search
        {
            get
            {
                return _search;
            }
            set
            {
                //Refresh the items list
                _search = value;
                OnPropertyChanged("Search");
                DoItemSearch();
            }
        }

        public ItemListViewModel()
        {
            LoadData();
        }

        async void LoadData()
        {
            if(AllItems == null)
                AllItems = await MHDatabaseHelper.GetAllItems();
        }

        private void DoItemSearch()
        {
            if (Search.Length == 0)
                Items = _allItems;
            else
                Items = _allItems.Where<Item>((i) => i.name.IndexOf(Search, StringComparison.CurrentCultureIgnoreCase) >= 0).ToList<Item>();
        }

    }
}
