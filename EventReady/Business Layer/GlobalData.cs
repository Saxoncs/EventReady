using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EventReady.Business_Layer;

namespace EventReady.Business_Layer
{
    public class GlobalData
    {
        public static List<String> guestList
        { get; set; }
        public static List<EventBL> Events { get; set; }
        public static Dictionary<string, UserBL> userMap { get; set; }
        
        public static List<UserBL> User1 { get; set; }

        //public static List<Guest> guestList { get; set; }
        static GlobalData()
        {
            //guestList = new List<Guest>();
            //guestList.Add(new Guest("randomemail@gmail.com", 1));
            guestList = new List<String>();
            guestList.Add("test@gmail.com");
            guestList.Add("check@gmail.com");
            guestList.Add("other@gmail.com");
            Events = new List<EventBL>();
            Events.Add(new EventBL("user@gmail.com", "Birthday", "18th birthday party", "bob", "done", "21/09/19", "2123 random place dr", "0432564356", "testemail@gmail.com", guestList));
            Events.Add(new EventBL("user@gmail.com", "Get together", "Big wedding", "josh", "hob", "12/02/19", "432 place dr", "0542564356", "randomemail@gmail.com", guestList));
            Events.Add(new EventBL("test@gmail.com", "Wedding", "Some other stuff", "dylon", "cobey", "30/04/19", "2123 random place dr", "0432564356", "otheremail@gmail.com", guestList));

            /*Events.Add(new EventBL("user@gmail.com", "Get together", "Big wedding", "josh", "hob", "15/11/19", "432 place dr", "0542564356", "randomemail@gmail.com", guestList));
            userMap = new Dictionary<string, User>();
            userMap.Add("user@gmail.com", new User("Jo", "Black", "user@gmail.com", "password"));

            Events.Add(new EventBL("user@gmail.com", "Get together", "Big wedding", "josh", "hob", "12/02/19", "432 place dr", "0542564356", "randomemail@gmail.com", guestList));
            // the user id here matches the userId of our main database test userId and is being used by most of the sight to display event information across the sight, this will need to be removed.
            userMap = new Dictionary<string, UserBL>();
            userMap.Add("user@gmail.com", new UserBL("Jo", "Black", "user@gmail.com", "password", "3282914"));*/


        }
    }
}