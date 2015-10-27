using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MH4U_Database.Database
{
    class Component
    {
        public long _id { get; set; }


        public int created_item_id { get; set; }
        public string created_item_name { get; set; }
        public int created_item_rarity { get; set; }
        public string created_item_subtype { get; set; }
        public string created_item_type { get; set; }
        public string created_item_icon { get; set; }
        public string created_icon_path { get {
                return "/Assets/icons_items/" + created_item_icon;
        }}

        public int comp_item_id { get; set; }
        public string comp_item_name { get; set; }
        public int comp_item_rarity { get; set; }
        public string comp_item_subtype { get; set; }
        public string comp_item_type { get; set; }
        public string comp_item_icon { get; set; }
        public string comp_item_icon_path
        {
            get
            {
                    return "/Assets/icons_items/" + comp_item_icon;

            }
        }

        public int quantity { get; set; }
        public string type { get; set; }
    }
}
