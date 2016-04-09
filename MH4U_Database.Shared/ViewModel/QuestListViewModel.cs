using MH4U_Database.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH4U_Database.ViewModel
{
    class QuestListViewModel : BaseViewModel
    {

        public class QuestHubGroup : ObservableCollection<Quest>
        {
            public QuestHubGroup(IEnumerable<Quest> items) : base(items)
            {

            }

            public int Stars { get; set; }

            public string StarString { get
                {
                    return Stars + "\u2605";
                } }

            public string StarString2
            {
                get
                {
                    string ret = "";
                    for (int i = 0; i < Stars; i++) ret += "\u2605";
                    return ret;
                }
            }
        }

        List<QuestHubGroup> _caravanQuests;
        public List<QuestHubGroup> CaravanQuests
        {
            get { return _caravanQuests; }
            set
            {
                _caravanQuests = value;
                OnPropertyChanged("CaravanQuests");
            }
        }

        List<QuestHubGroup> _guildQuests;
        public List<QuestHubGroup> GuildQuests
        {
            get { return _guildQuests; }
            set
            {
                _guildQuests = value;
                OnPropertyChanged("GuildQuests");
            }
        }

        List<QuestHubGroup> _eventQuests;
        public List<QuestHubGroup> EventQuests
        {
            get { return _eventQuests; }
            set
            {
                _eventQuests = value;
                OnPropertyChanged("EventQuests");
            }
        }


        public QuestListViewModel()
        {
            LoadData();
        }

        async void LoadData()
        {
            if(CaravanQuests == null)
                CaravanQuests = (from item in (await MHDatabaseHelper.GetAllQuestsForHub("Caravan"))
                                 group item by item.stars into questGroup
                                 select new QuestHubGroup(questGroup){ Stars = questGroup.Key}).ToList();
            if (GuildQuests == null)
                GuildQuests = (from item in (await MHDatabaseHelper.GetAllQuestsForHub("Guild"))
                                 group item by item.stars into questGroup
                                 select new QuestHubGroup(questGroup) { Stars = questGroup.Key }).ToList();
            if (EventQuests == null)
                EventQuests = (from item in (await MHDatabaseHelper.GetAllQuestsForHub("Event"))
                               group item by item.stars into questGroup
                               select new QuestHubGroup(questGroup) { Stars = questGroup.Key }).ToList();
        }

    }
}
