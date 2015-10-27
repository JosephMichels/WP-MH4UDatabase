using MH4U_Database.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH4U_Database.ViewModel
{
    class SkillDetailsViewModel :BaseViewModel
    {
        List<Skill> _skills;
        public List<Skill> Skills
        {
            get { return _skills; }
            set
            {
                _skills = value;
                OnPropertyChanged("Skills");
            }
        }

        SkillTree _skillTree;
        public SkillTree SkillTree
        {
            get { return _skillTree; }
            set
            {
                _skillTree = value;
                OnPropertyChanged("SkillTree");
            }
        }

        public SkillDetailsViewModel(int id)
        {
            LoadData(id);
        }

        async void LoadData(int id)
        {
            if (Skills == null)
                Skills = await MHDatabaseHelper.GetSkillsForSkillTree(id);
            if (SkillTree == null)
                SkillTree = await MHDatabaseHelper.GetSkillTree(id);
        }
    }
}
