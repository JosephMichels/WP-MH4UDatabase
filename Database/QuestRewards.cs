using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MH4U_Database.Database
{
    class QuestRewards
    {
        public long _id { get; set; }
        public string reward_slot { get; set; }
        public int percentage { get; set; }
        public int stack_size { get; set; }

        //Item Properties
        public long item_id { get; set; }
        public string item_name { get; set; }
        public string item_icon { get; set; }
        public string item_icon_path { get { return "/Assets/icons_items/" + item_icon; } }

        //Quest Properties
        public long quest_id { get; set; }
        public string quest_name { get; set; }
        public string quest_hub { get; set; }       //Caravan/Guild
        public string quest_stars { get; set; }     //1-?
    }
}
