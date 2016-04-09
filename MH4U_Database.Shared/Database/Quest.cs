using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH4U_Database.Database
{
    class Quest
    {
        public int _id { get; set; }
        public string name { get; set; }
        public string goal { get; set; }
        public string hub { get; set; }
        public string type { get; set; }
        public int stars { get; set; }

        public string type_display { get
            {
                if (type.Equals("Normal")) return "";
                return type;
            } }

        //Location info
        public int location_id { get; set; }
        public string location_name { get; set; } //JOIN

        public int fee { get; set; }
        public int reward { get; set; }
        public int hrp { get; set; }

        //Sub Quest Info
        public string sub_goal { get; set; }
        public int sub_reward { get; set; }
        public int sub_hrp { get; set; }
    }
}
