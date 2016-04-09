using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH4U_Database.Database
{
    class Decoration
    {
        public int _id { get; set; }
        public int num_slots { get; set; }

        //Nice string formatting of slots
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

        public string item_name { get; set; }
        public int item_rarity { get; set; }
        public string icon_name { get; set; }
        public string icon_path
        {
            get
            {
                return "/Assets/icons_items/" + icon_name;
            }
        }

    }
}
