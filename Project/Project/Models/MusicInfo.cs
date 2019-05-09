using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Models
{
    public class MusicInfo
    {
        public string vocalinstrumental { get; set; }
        public string lang { get; set; }
        public string gender { get; set; }
        public string acousticelectric { get; set; }
        public string speed { get; set; }
        public Tags tags { get; set; }
    }
}
