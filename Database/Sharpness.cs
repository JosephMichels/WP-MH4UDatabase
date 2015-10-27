using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MH4U_Database.Database
{
    public class Sharpness
    {
        public int Red { get; set; }
        public int Orange { get; set; }
        public int Yellow { get; set; }
        public int Green { get; set; }
        public int Blue { get; set; }
        public int White { get; set; }
        public int Purple { get; set; }
        public int Black
        {
            get
            {
                return 70 - (Red + Orange + Yellow + Green + Blue + White + Purple);
            }
        }

        public int Red1 { get; set; }
        public int Orange1 { get; set; }
        public int Yellow1 { get; set; }
        public int Green1 { get; set; }
        public int Blue1 { get; set; }
        public int White1 { get; set; }
        public int Purple1 { get; set; }
        public int Black1
        {
            get
            {
                return 70 - (Red1 + Orange1 + Yellow1 + Green1 + Blue1 + White1 + Purple1);
            }
        }
    }
}
