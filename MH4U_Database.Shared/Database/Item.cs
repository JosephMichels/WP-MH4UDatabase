using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MH4U_Database.Database
{
    public class Item
    {
        public int _id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string sub_type { get; set; }
        public int rarity { get; set; }
        public string description { get; set; }
        public string icon_name { get; set; }
        public string icon_path { get {
               return "/Assets/icons_items/" + icon_name;
        } }
    }
}
