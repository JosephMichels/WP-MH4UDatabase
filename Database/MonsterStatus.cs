using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH4U_Database.Database
{
    class MonsterStatus
    {
        public int _id { get; set; }
        public int monster_id { get; set; }

        public string status { get; set; }
        public int initial { get; set; }
        public int increase { get; set; }
        public int max { get; set; }
        public int duration { get; set; }
        public int damage { get; set; }
    }
}
