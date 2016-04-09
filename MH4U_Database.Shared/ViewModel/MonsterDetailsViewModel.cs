using MH4U_Database.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH4U_Database.ViewModel
{
    class MonsterDetailsViewModel : BaseViewModel
    {
        List<MonsterDamage> _damages;
        public List<MonsterDamage> Damages
        {
            get { return _damages; }
            set
            {
                _damages = value;
                OnPropertyChanged("Damages");
            }
        }

        Monster _monster;
        public Monster Monster { get { return _monster; }
            set {
                _monster = value;
                OnPropertyChanged("Monster");
            }
        }

        List<MonsterStatus> _status;
        public List<MonsterStatus> Statuses
        {
            get { return _status; }
            set
            {
                _status = value;
                OnPropertyChanged("Statuses");
            }
        }

        List<Habitat> _habitats;
        public List<Habitat> Habitats
        {
            get { return _habitats; }
            set
            {
                _habitats = value;
                OnPropertyChanged("Habitats");
            }
        }

        public class HuntingRewardGroup : ObservableCollection<HuntingReward>
        {
            public HuntingRewardGroup(IEnumerable<HuntingReward> items) : base(items)
            {

            }

            public string Condition { get; set; }
        }

        List<HuntingRewardGroup> _lowHuntingRewardGroup;
        public List<HuntingRewardGroup> LowHuntingRewardGroup
        {
            get { return _lowHuntingRewardGroup; }
            set
            {
                _lowHuntingRewardGroup = value;
                OnPropertyChanged("LowHuntingRewardGroup");
            }
        }

        List<HuntingRewardGroup> _highHuntingRewardGroup;
        public List<HuntingRewardGroup> HighHuntingRewardGroup
        {
            get { return _highHuntingRewardGroup; }
            set
            {
                _highHuntingRewardGroup = value;
                OnPropertyChanged("HighHuntingRewardGroup");
            }
        }

        List<HuntingRewardGroup> _gHuntingRewardGroup;
        public List<HuntingRewardGroup> GHuntingRewardGroup
        {
            get { return _gHuntingRewardGroup; }
            set
            {
                _gHuntingRewardGroup = value;
                OnPropertyChanged("GHuntingRewardGroup");
            }
        }

        List<Quest> _quests;
        public List<Quest> Quests
        {
            get { return _quests; }
            set
            {
                _quests = value;
                OnPropertyChanged("Quests");
            }
        }

        public MonsterDetailsViewModel(int id)
        {
            LoadData(id);
        }

        async void LoadData(int id)
        {
            if (Monster == null)
                Monster = await MHDatabaseHelper.GetMonster(id);
            if (Damages == null)
                Damages = await MHDatabaseHelper.GetMonsterDamageForMonster(id);
            if (Statuses == null)
                Statuses = await MHDatabaseHelper.GetMonsterStatusForMonster(id);

            if (Habitats == null)
                Habitats = await MHDatabaseHelper.GetHabitatForMonster(id);

            //Crazy LINQ queries that get the hunting rewards grouped by condition.
            if (LowHuntingRewardGroup == null)
                LowHuntingRewardGroup = (from item in (await MHDatabaseHelper.GetHuntingRewardsForMonsterRank(id, "LR"))
                                         group item by item.condition into huntGroup
                                         select new HuntingRewardGroup(huntGroup) { Condition = huntGroup.Key }).ToList();
            if (HighHuntingRewardGroup == null)
                HighHuntingRewardGroup = (from item in (await MHDatabaseHelper.GetHuntingRewardsForMonsterRank(id, "HR"))
                                          group item by item.condition into huntGroup
                                          select new HuntingRewardGroup(huntGroup) { Condition = huntGroup.Key }).ToList();
            if (GHuntingRewardGroup == null)
                GHuntingRewardGroup = (from item in (await MHDatabaseHelper.GetHuntingRewardsForMonsterRank(id, "G"))
                                       group item by item.condition into huntGroup
                                       select new HuntingRewardGroup(huntGroup) { Condition = huntGroup.Key }).ToList();

            if (Quests == null)
                Quests = await MHDatabaseHelper.GetQuestsForMonster(id);
        }
    }
}
