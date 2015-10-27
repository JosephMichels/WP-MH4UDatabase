using MH4U_Database.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH4U_Database.ViewModel
{
    class QuestDetailsViewModel : BaseViewModel
    {
        Quest _quest;
        public Quest Quest
        {
            get { return _quest; }
            set
            {
                _quest = value;
                OnPropertyChanged("Quest");
            }
        }

        List<Monster> _monsters;
        public List<Monster> Monsters
        {
            get { return _monsters; }
            set
            {
                _monsters = value;
                OnPropertyChanged("Monsters");
            }
        }

        List<RewardGroup> _rewards;
        public List<RewardGroup> Rewards
        {
            get { return _rewards; }
            set
            {
                _rewards = value;
                OnPropertyChanged("Rewards");
            }
        }

        public class RewardGroup : ObservableCollection<QuestRewards>
        {
            public RewardGroup(IEnumerable<QuestRewards> items) : base(items)
            {

            }

            public string Slot { get; set; }
        }

        public QuestDetailsViewModel(int id)
        {
            LoadData(id);
        }


        async void LoadData(int id)
        {
            if (Quest == null)
                Quest = await MHDatabaseHelper.GetQuest(id);
            if (Monsters == null)
                Monsters = await MHDatabaseHelper.GetMonstersForQuest(id);
            if (Rewards == null)
                Rewards = (from item in (await MHDatabaseHelper.GetQuestRewardsForQuest(id))
                           group item by item.reward_slot into rewardGroup
                           select new RewardGroup(rewardGroup) { Slot = rewardGroup.Key }).ToList();
        }

    }
}
