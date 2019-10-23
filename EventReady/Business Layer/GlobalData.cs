using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EventReady.Business_Layer;

namespace EventReady.Business_Layer
{
    public class GlobalData
    {
        public static List<EventBL> Events { get; set; }
        public static Dictionary<string, User> userMap { get; set; }
        
        public static List<User> User1 { get; set; }
        static GlobalData()
        {
            Events = new List<EventBL>();
            Events.Add(new EventBL("Birthday", "18th birthday party", 5));
            Events.Add(new EventBL("Party", "Big party at my fav resturant", 5));
            Events.Add(new EventBL("Get together", "Some random text that will do somethibg", 5));

            userMap = new Dictionary<string, User>();
            userMap.Add("user@gmail.com", new User("Jo", "Black", "user@gmail.com", "password", "43 random dr City 2131"));

            User1 = new List<User>();
            User1.Add(new User("Jo", "Black", "user@gmail.com", "password1", "43 random dr City 2131"));
        }
    }
}