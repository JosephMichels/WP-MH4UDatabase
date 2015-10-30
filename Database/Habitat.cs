using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH4U_Database.Database
{
    class Habitat
    {
        public int _id { get; set; }
        public int monster_id { get; set; }

        public int location_id { get; set; }
        public string location_name { get; set; }

        public int start_area { get; set; }
        public string move_area { get; set; }
        public int rest_area { get; set; }
    }
}
