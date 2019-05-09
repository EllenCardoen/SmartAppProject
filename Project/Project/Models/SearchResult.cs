using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Models
{

    public class SearchResult
    {
        public Headers headers { get; set; }
        public Results results { get; set; }
    }

    public class Headers
    {
        public string status { get; set; }
        public int code { get; set; }
        public string error_message { get; set; }
        public string warnings { get; set; }
        public int results_count { get; set; }
    }

    public class Results
    {
        public string[] tracks { get; set; }
        public string[] artists { get; set; }
        public string[] albums { get; set; }
        public string[] tags { get; set; }
    }

}
