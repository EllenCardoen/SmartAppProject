using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Models
{
    public class Playlist
    {
        public string id { get; set; }
        public string name { get; set; }
        public string creationdate { get; set; }
        public string user_id { get; set; }
        public string user_name { get; set; }
        public string zip { get; set; }
        public string shorturl { get; set; }
        public string shareurl { get; set; }
    }
}
