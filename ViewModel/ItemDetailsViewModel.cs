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
    class ItemDetailsViewModel : BaseViewModel
    {

        Item _item;
        public Item Item { get { return _item; }
            set
            {
                _item = value;
                OnPropertyChanged("Item");
                Debug.WriteLine("Item Loaded");
            }
        }

        List<Component> _components;
        public List<Component> Components
        {
            get { return _components; }
            set
            {
                _components = value;
                OnPropertyChanged("Components");
            }
        }

        List<HuntingReward> _monsters;
        public List<HuntingReward> Monsters
        {
            get
            {
                return _monsters;
            }
            set
            {
                _monsters = value;
                OnPropertyChanged("Monsters");
            }
        }

        List<Gathering> _gathering;
        public List<Gathering> Gathering
        {
            get { return _gathering; }
            set
            {
                _gathering = value;
                OnPropertyChanged("Gathering");
            }
        }

        List<QuestRewards> _quests;
        public List<QuestRewards> Quests
        {
            get { return _quests; }
            set { _quests = value;
                OnPropertyChanged("Quests");
            }
        }

        public ItemDetailsViewModel(long id)
        {
            LoadData(id);
        }

        public async void LoadData(long id)
        {
            if(Item == null)
                Item = await MHDatabaseHelper.GetItem(id);
            if (Components == null)
                Components = await MHDatabaseHelper.GetComponentsForComponent(id);
            if (Monsters == null)
                Monsters = await MHDatabaseHelper.GetHuntingRewardsForItem(id);
            if (Gathering == null)
                Gathering = await MHDatabaseHelper.GetGatheringRewardsForItem(id);
            if (Quests == null)
                Quests = await MHDatabaseHelper.GetQuestRewardsForItem(id);
        }

    }
}
