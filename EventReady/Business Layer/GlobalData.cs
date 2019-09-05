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
        public static Dictionary<string, User> userMap { get; set; }
        
        static GlobalData()
        {
            Events = new List<Event>();
            Events.Add(new Event("Birthday", "18th birthday party", 5));
            Events.Add(new Event("Party", "Big party at my fav resturant", 5));
            Events.Add(new Event("Get together", "Some random text that will do somethibg", 5));

            userMap = new Dictionary<string, User>();
            userMap.Add("user@gmail.com", new User("Jo", "Black", "user@gmail.com", "password", "43 random dr City 2131"));
        }
    }
}