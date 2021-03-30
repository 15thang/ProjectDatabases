using System;

namespace SomerenModel
{
    public class WeekRoster
    {
        // Thomas Eddyson
        public DateTime Date { get; set; }

        public int DayOfWeek { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ActivityName { get; set; }
        public DateTime BeginTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}