using MH4U_Database.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH4U_Database.ViewModel
{
    class WyporiumViewModel : BaseViewModel
    {

        List<WyporiumTrade> _trades;
        public List<WyporiumTrade> Trades
        {
            get { return _trades; }
            set
            {
                _trades = value;
                OnPropertyChanged("Trades");
            }
        }

        bool _showUnlock;
        public bool ShowUnlock
        {
            get { return _showUnlock; }
            set
            {
                _showUnlock = value;
                OnPropertyChanged("ShowUnlock");
            }
        }

        public WyporiumViewModel()
        {
            LoadData();
        }

        public async void LoadData()
        {
            if (Trades == null)
                Trades = await MHDatabaseHelper.GetWyporiumTrades();
        }
    }
}
