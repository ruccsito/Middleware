using System.Collections.Generic;

namespace MiddlewareWeb.Models
{
    public class FormData
    {
        public string id { get; set; }
        public string name { get; set; }
        public string placeholder { get; set; }
        public List<string> options { get; set; }
    }
}