using MH4U_Database.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH4U_Database.ViewModel
{
    class DecorationDetailsViewModel : BaseViewModel
    {
        Decoration _decoration;
        public Decoration Decoration
        {
            get { return _decoration; }
            set
            {
                _decoration = value;
                OnPropertyChanged("Decoration");
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
        public List<ItemToSkillTree> Skills
        {
            get { return _skills; }
            set
            {
                _skills = value;
                OnPropertyChanged("Skills");
            }
        }

        //TODO:Add skills

        public DecorationDetailsViewModel(int id)
        {
            LoadData(id);
        }

        async void LoadData(int id)
        {
            if (Decoration == null)
                Decoration = await MHDatabaseHelper.GetDecoration(id);
            if (Components == null)
                Components = await MHDatabaseHelper.GetComponentsForItem(id);
            if (Skills == null)
                Skills = await MHDatabaseHelper.GetSkillTreesForItem(id);
        }
    }
}
