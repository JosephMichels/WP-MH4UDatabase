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

        public char song_note_1 { get { return song[0]; } }
        public char song_note_2 { get { return song[1]; } }
        public char song_note_3 { get { return ((song.Length < 3) ? ' ' : song[2]); } }
        public char song_note_4 { get { return ((song.Length < 4) ? ' ' : song[3]); } }
    }
}
