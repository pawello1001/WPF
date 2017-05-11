using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjektWPF
{
    public class Alarm
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DateTime date { get; set; }
        public DateTime hour { get; set; }
    }
}
