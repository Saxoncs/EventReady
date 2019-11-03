using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static EventReady.Data_Access_Layer.UserDataAccess;

namespace EventReady.Business_Layer
{
    public class UserBL
    {
        public UserBL(string firstName, string lastName, string email, string password, string userId)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            UserId = userId;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserId { get; set; }


    //Finds a user from the database using the email they submit
    public UserBL GetActiveUser(string loginEmail)
        {

            User user = GetUser(loginEmail);

            string firstName = user.firstName;
            string lastName = user.lastName;
            string email = user.email;
            string password = user.password;
            string userId = user.userId;

            UserBL activeUser = new UserBL(firstName, lastName, email, password, userId);
            return activeUser;
        }
    }
}