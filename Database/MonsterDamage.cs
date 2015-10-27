using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH4U_Database.Database
{
    class MonsterDamage
    {
        public string body_part { get; set; }
        public int cut { get; set; }
        public int impact { get; set; }
        public int shot { get; set; }

        public int fire { get; set; }
        public int water { get; set; }
        public int ice { get; set; }
        public int thunder { get; set; }
        public int dragon { get; set; }
        public int ko { get; set; }
        public string ko_string { get
            {
                if (ko == -1) return "--";
                return ko.ToString();
            } }
    }
}
