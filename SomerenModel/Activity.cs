using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class Activity
    {
        // Tim Roffelsen
        public int ActivityId { get; set; }
        public string Type { get; set; } // type of activity
        public DateTime BeginTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
