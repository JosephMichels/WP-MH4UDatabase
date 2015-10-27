using MH4U_Database.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH4U_Database.ViewModel
{
    class SkillListViewModel : BaseViewModel
    {
        List<SkillTree> _skillTrees;
        public List<SkillTree> SkillTrees
        {
            get { return _skillTrees; }
            set
            {
                _skillTrees = value;
                OnPropertyChanged("SkillTrees");
            }
        }

        public SkillListViewModel()
        {
            LoadData();
        }

        async void LoadData()
        {
            if (SkillTrees == null)
                SkillTrees = await MHDatabaseHelper.GetAllSkillTrees();
        }
    }
}
