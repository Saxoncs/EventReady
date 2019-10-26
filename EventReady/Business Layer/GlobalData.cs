﻿using System;
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
        public static Dictionary<string, User> userMap { get; set; }
        
        public static List<User> User1 { get; set; }
        static GlobalData()
        {
            guestList = new List<String>();
            guestList.Add("test@gmail.com");
            guestList.Add("check@gmail.com");
            guestList.Add("other@gmail.com");
            Events = new List<EventBL>();
            Events.Add(new EventBL("user@gmail.com", "Birthday", "18th birthday party", "bob", "done", "21/09/19", "2123 random place dr", "0432564356", "testemail@gmail.com", guestList));
            Events.Add(new EventBL("user@gmail.com", "Get together", "Big wedding", "josh", "hob", "12/02/19", "432 place dr", "0542564356", "randomemail@gmail.com", guestList));
            Events.Add(new EventBL("user@gmail.com", "Wedding", "Some other stuff", "dylon", "cobey", "30/04/19", "2123 random place dr", "0432564356", "otheremail@gmail.com", guestList));

            userMap = new Dictionary<string, User>();
            userMap.Add("user@gmail.com", new User("Jo", "Black", "user@gmail.com", "password", "43 random dr City 2131"));

            User1 = new List<User>();
            User1.Add(new User("Jo", "Black", "user@gmail.com", "password1", "43 random dr City 2131"));
        }
    }
}