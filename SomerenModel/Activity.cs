using System;

namespace SomerenModel
{
    public class Activity
    {
        // Tim Roffelsen
        public int ActivityId { get; set; }

        public string Type { get; set; } // type of activity
        public DateTime BeginTime { get; set; }
        public DateTime EndTime { get; set; }

        public override bool Equals(object obj)
        {
            // Tim Roffelsen
            // Makes two objects equal even if they aren't the same referenced object
            var other = obj as Activity;

            if (other == null)
            {
                return false;
            }
            if (ActivityId != other.ActivityId || Type != other.Type || BeginTime != other.BeginTime || EndTime != other.EndTime)
            {
                return false;
            }
            return true;
        }
    }
}