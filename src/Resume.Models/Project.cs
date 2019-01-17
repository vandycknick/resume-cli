using System;
using System.Collections.Generic;

namespace Resume.Models
{
    public class Project
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Highlights { get; set; }
        public List<string> Keywords { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Url { get; set; }
        public List<string> Roles { get; set; }
        public string Entity { get; set; }
        public string Type { get; set; }
    }
}
