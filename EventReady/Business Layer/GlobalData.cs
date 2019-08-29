using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EventReady.Business_Layer;

namespace EventReady.Business_Layer
{
    public class GlobalData
    {
        public static List<Event> Events { get; set; }
        //Orders = new List<Order>();
        //Orders.Add(new Order("basicuser@bu.com", "kqqqqqqq", "kqqqqqqqqq", "0404040404", "123 fake st", "kqqqqq", "1234", null, "k@k.com",0, productList, "Processing", Convert.ToString(DateTime.Now)));
        static GlobalData()
        {
            Events = new List<Event>();
            Events.Add(new Event("Birthday", "18th birthday party", 5));
            Events.Add(new Event("Party", "Big party at my fav resturant", 5));
            Events.Add(new Event("Get together", "Some random text that will do somethibg", 5));
        }
    }
}