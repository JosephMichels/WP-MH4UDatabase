using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MH4U_Database.Database
{
    class HuntingReward
    {
        public int _id { get; set; }
        public string condition { get; set; }
        public int percentage { get; set; }
        public string rank { get; set; }
        public int stack_size { get; set; }

        //Item Variables
        public string item_name { get; set; }
        public int item_id { get; set; }
        public string item_icon { get; set; }
        public string item_icon_path
        {
            get
            {
                return "/Assets/icons_items/" + item_icon;
            }
        }

        //Monster Variables
        public string monster_name { get; set; }
        public int monster_id { get; set; }
        public string monster_icon { get; set; }
        public string monster_icon_path
        {
            get
            {
                return "/Assets/icons_monster/" + monster_icon;
            }
        }

    }
}
