using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventReady.Business_Layer
{
    public class Event
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int DurationModifier { get; set; }

        public string id { get; set; }

        public Event(string name, string description, int durationmodifier)
        {
            Name = name;
            Description = description;
            DurationModifier = durationmodifier;
        }
    }
}