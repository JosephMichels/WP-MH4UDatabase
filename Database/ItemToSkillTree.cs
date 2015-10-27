using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH4U_Database.Database
{
    class ItemToSkillTree
    {
        public int _id { get; set; }
        public int item_id { get; set; }

        //JOIN with skill data
        public int skill_tree_id { get; set; }
        public string skill_tree_name { get; set; }

        public int point_value { get; set; }

        public string point_value_string { get
            {
                //If positive, add a '+'
                if (point_value > 0)
                    return "+" + point_value;
                return point_value.ToString();
            } }
    }
}
