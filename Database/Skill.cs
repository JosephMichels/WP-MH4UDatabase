using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH4U_Database.Database
{
    class Skill
    {
        public int _id { get; set; }
        public int skill_tree_id { get; set; }
        public int required_skill_tree_points { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }
}
