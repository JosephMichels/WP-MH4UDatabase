using MH4U_Database.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace MH4U_Database.ViewModel
{
    class FelyneSkillListViewModel : BaseViewModel
    {

        List<FelyneSkill> _skills;
        public List<FelyneSkill> Skills { get { return _skills; }
        set
            {
                _skills = value;
                OnPropertyChanged(nameof(Skills));
            }
        }

        public FelyneSkillListViewModel()
        {
            LoadData();
        }

        async void LoadData()
        {
            if (Skills == null)
                Skills = await MHDatabaseHelper.GetFelyneSkills();
        }

    }
}
