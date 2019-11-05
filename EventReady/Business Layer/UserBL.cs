using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static EventReady.Data_Access_Layer.UserDataAccess;

namespace EventReady.Business_Layer
{
    public class UserBL
    {
        public UserBL()
        {

        }

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


    //Finds a user from the database using the Id being stored in session data -Saxon
    public UserBL GetActiveUser(string userSessionId)
        {

            User user = GetUser(userSessionId);

            string firstName = user.firstName;
            string lastName = user.lastName;
            string email = user.email;
            string password = user.password;
            string userId = user.userId;

            UserBL activeUser = new UserBL(firstName, lastName, email, password, userId);
            return activeUser;
        }



        //Finds a user from the database using the email they submit - Saxon
        public UserBL GetLogingUser(string loginEmail)
        {

            User user = UserLoginAttempt(loginEmail);

            string firstName = user.firstName;
            string lastName = user.lastName;
            string email = user.email;
            string password = user.password;
            string userId = user.userId;

            UserBL activeUser = new UserBL(firstName, lastName, email, password, userId);
            return activeUser;
        }

        public void CreateNewUser(string firstName, string lastName, string email, string password)
        {
            User newUser = new User();

            newUser.active = true;
            newUser.firstName = firstName;
            newUser.email = email;
            newUser.lastName = lastName;
            newUser.password = password;

            //this will need to be removed with the database restructure.
            newUser.userId = "0000001";

            AddUser(newUser);



        }



    }
}