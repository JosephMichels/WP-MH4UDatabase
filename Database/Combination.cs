using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH4U_Database.Database
{
    class Combination
    {
        public int created_item_id { get; set; }
        public string created_item_name { get; set; }
        public string created_item_icon { get; set; }
        public string created_item_icon_path
        {
            get
            {
                return "/Assets/icons_items/" + created_item_icon;
            }
        }

        public int item_1_id { get; set; }
        public string item_1_name { get; set; }
        public string item_1_icon { get; set; }
        public string item_1_icon_path
        {
            get
            {
                return "/Assets/icons_items/" + item_1_icon;
            }
        }

        public int item_2_id { get; set; }
        public string item_2_name { get; set; }
        public string item_2_icon { get; set; }
        public string item_2_icon_path
        {
            get
            {
                return "/Assets/icons_items/" + item_2_icon;
            }
        }

        public int percentage { get; set; }
        public int amount_made_min { get; set; }
        public int amount_made_max { get; set; }

        public string amount_made_string {
            get
            {
                if (amount_made_max == amount_made_min) return amount_made_min.ToString();
                return amount_made_min.ToString() + "-" + amount_made_max.ToString();
            }
        }
    }
}
