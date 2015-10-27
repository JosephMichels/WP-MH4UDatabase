using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH4U_Database.Database
{
    class Armor
    {
        public int _id { get; set; }
        public string slot { get; set; }
        public int defense { get; set; }
        public int max_defense { get; set; }

        public int fire_res { get; set; }
        public int thunder_res { get; set; }
        public int dragon_res { get; set; }
        public int water_res { get; set; }
        public int ice_res { get; set; }

        public string gender { get; set; }
        public string hunter_type { get; set; }
        public int num_slots { get; set; }


        //Item Stuff
        public string item_name { get; set; }
        public int rarity { get; set; }
        public string icon_name { get; set; }
        public string icon_path { get
            {
                return "/Assets/icons_items/" + icon_name;
            } }


        public string slots
        {
            get
            {
                switch (num_slots)
                {
                    case 0: return "---";
                    case 1: return "\u25CB--";
                    case 2: return "\u25CB\u25CB-";
                    case 3: return "\u25CB\u25CB\u25CB";
                    default: return "Error";
                }
            }
        }
    }
}
