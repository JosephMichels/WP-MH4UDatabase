using MH4U_Database.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH4U_Database.ViewModel
{
    class ArmorDetailsViewModel : BaseViewModel
    {

        Armor _armor;
        public Armor Armor { get { return _armor; }
            set
            {
                _armor = value;
                OnPropertyChanged("Armor");
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

        List<ItemToSkillTree> _skills;
        public List<ItemToSkillTree> Skills { get { return _skills; } set
            {
                _skills = value;
                OnPropertyChanged("Skills");
            } }

        //TODO:Add skills

        public ArmorDetailsViewModel(int id)
        {
            LoadData(id);
        }

        async void LoadData(int id)
        {
            if (Armor == null)
                Armor = await MHDatabaseHelper.GetArmor(id);
            if (Components == null)
                Components = await MHDatabaseHelper.GetComponentsForItem(id);
            if (Skills == null)
                Skills = await MHDatabaseHelper.GetSkillTreesForItem(id);
        }

    }
}
