using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH4U_Database.Database
{
    class HornMelody
    {
        public int _id { get; set; }
        public string notes { get; set; }
        public string song { get; set; }
        public string effect1 { get; set; }
        public string effect2 { get; set; }
        public string duration { get; set; }
        public string extension { get; set; }
    }
}
