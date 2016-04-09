using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MH4U_Database.Database
{
    public class Monster
    {
        public int _id{get;set;}

        public string name { get; set; }

        public string trait { get; set; }

        public string icon_name { get; set; }

        public string signature_move { get; set; }

        public string icon_path { get { return "/Assets/icons_monster/" + icon_name; } }
    }
}
