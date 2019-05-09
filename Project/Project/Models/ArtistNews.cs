using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Models
{
    public class ArtistNews
    {
        public string id { get; set; }
        public Lang title { get; set; }
        public string link { get; set; }
        public string position { get; set; }
        public string[] lang { get; set; }
        public string date_start { get; set; }
        public string date_end { get; set; }
        public Lang text { get; set; }
        public string type { get; set; }
        public string joinid { get; set; }
        public object[] subtitle { get; set; }
        public string target { get; set; }
        public Images images { get; set; }

    }
}
