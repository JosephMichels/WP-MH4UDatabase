using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH4U_Database.Database
{
    class MonsterWeakness
    {
        public string state { get; set; }
        public int fire { get; set; }
        public int water { get; set; }
        public int thunder { get; set; }
        public int ice { get; set; }
        public int dragon { get; set; }


        public int poison { get; set; }
        public int paralysis { get; set; }
        public int sleep { get; set; }


        public int pitfall_trap { get; set; }
        public int shock_trap { get; set; }


        public int flash_bomb { get; set; }
        public int sonic_bomb { get; set; }
        public int dung_bomb { get; set; }
        public int meat { get; set; }
    }
}
