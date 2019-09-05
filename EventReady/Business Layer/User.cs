﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventReady.Business_Layer
{
    public class User
    {
        public User(string firstName, string lastName, string email, string password, string address)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            Address = address;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
    }


}