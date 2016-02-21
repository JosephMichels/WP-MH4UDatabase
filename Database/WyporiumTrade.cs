using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH4U_Database.Database
{
    class WyporiumTrade
    {
        public int _id { get; set; }

        //In Item
        public int item_in_id { get; set; }
        public string item_in_name { get; set; }
        public string item_in_icon { get; set; }
        public string item_in_icon_path
        {
            get
            {
                return "/Assets/icons_items/" + item_in_icon;
            }
        }

        //Out Item
        public int item_out_id { get; set; }
        public string item_out_name { get; set; }
        public string item_out_icon { get; set; }
        public string item_out_icon_path
        {
            get
            {
                return "/Assets/icons_items/" + item_out_icon;
            }
        }

        //Unlock Quest
        public int unlock_quest_id { get; set; }
        public string quest_name { get; set; }
        public int quest_stars { get; set; }
        public string quest_hub { get; set; }


        public string quest_string { get
            {
                return "Unlock: "+ quest_stars + "\u2605 " + quest_hub + " : " + quest_name;
            } }
    }
}
