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

        List<ItemToSkillTree> _headArmor;
        public List<ItemToSkillTree> HeadArmor
        {
            get { return _headArmor; }
            set
            {
                _headArmor = value;
                OnPropertyChanged("HeadArmor");
            }
        }

        List<ItemToSkillTree> _bodyArmor;
        public List<ItemToSkillTree> BodyArmor
        {
            get { return _bodyArmor; }
            set
            {
                _bodyArmor = value;
                OnPropertyChanged("BodyArmor");
            }
        }

        List<ItemToSkillTree> _armsArmor;
        public List<ItemToSkillTree> ArmsArmor
        {
            get { return _armsArmor; }
            set
            {
                _armsArmor = value;
                OnPropertyChanged("ArmsArmor");
            }
        }

        List<ItemToSkillTree> _waistArmor;
        public List<ItemToSkillTree> WaistArmor
        {
            get { return _waistArmor; }
            set
            {
                _waistArmor = value;
                OnPropertyChanged("WaistArmor");
            }
        }

        List<ItemToSkillTree> _legsArmor;
        public List<ItemToSkillTree> LegsArmor
        {
            get { return _legsArmor; }
            set
            {
                _legsArmor = value;
                OnPropertyChanged("LegsArmor");
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

            //TODO:Probably can make this better
            if (HeadArmor == null)
                HeadArmor = await MHDatabaseHelper.GetArmorForSkillTree(id, "Head");
            if (BodyArmor == null)
                BodyArmor = await MHDatabaseHelper.GetArmorForSkillTree(id, "Body");
            if (ArmsArmor == null)
                ArmsArmor = await MHDatabaseHelper.GetArmorForSkillTree(id, "Arms");
            if (WaistArmor == null)
                WaistArmor = await MHDatabaseHelper.GetArmorForSkillTree(id, "Waist");
            if (LegsArmor == null)
                LegsArmor = await MHDatabaseHelper.GetArmorForSkillTree(id, "Legs");
        }
    }
}
