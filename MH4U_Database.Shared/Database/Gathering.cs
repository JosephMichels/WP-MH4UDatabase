using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MH4U_Database.Database
{
    class Gathering
    {
        public int _id { get; set; }
        public int item_id { get; set; }
        public int location_id { get; set; }
        public string site { get; set; }    //Fish/Gather/Bug/Mine
        public string area { get; set; }    //Area ?
        public string rank { get; set; }    //LR/HR/G
        public int percentage { get; set; }

        //Location
        public string location_name { get; set; }

        //Item
        public string item_name { get; set; }
        public string item_icon { get; set; }
        public string item_icon_path { get { return "/icons_items/" + item_icon; } }

    }
}
