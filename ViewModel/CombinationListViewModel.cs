using MH4U_Database.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH4U_Database.ViewModel
{
    class CombinationListViewModel : BaseViewModel
    {
        List<Combination> _combinations;
        public List<Combination> Combinations
        {
            get { return _combinations; }
            set
            {
                _combinations = value;
                OnPropertyChanged("Combinations");
            }
        }

        public CombinationListViewModel()
        {
            LoadData();
        }

        async void LoadData()
        {
            if (Combinations == null)
                Combinations = await MHDatabaseHelper.GetAllCombinations();
        }
    }
}
