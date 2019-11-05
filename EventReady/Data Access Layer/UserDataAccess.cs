using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;

namespace EventReady.Data_Access_Layer
{
    [DataObject(true)]
    public class UserDataAccess
    {
        //the User class mirrors a row in the userInfo data table - Saxon
        public class User
        {

            public string userId { get; set; }
            public string email { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string password { get; set; }
            public bool active { get; set; }

        }

        //Take the User associated with a specified userID and return a User class - Saxon
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static User GetUser(string userId)
        {
            User user = new User();
            string sql = "SELECT userId, email, firstName, lastName, password, active FROM userInfo WHERE userId = @userId";

            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("userId", userId);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    user.userId = dr["userId"].ToString();
                    user.email = dr["email"].ToString();
                    user.firstName = dr["firstName"].ToString();
                    user.lastName = dr["lastName"].ToString();
                    user.password = dr["password"].ToString();
                    user.active = dr.GetBoolean(dr.GetOrdinal("active"));
                    dr.Close();
                }
            }
            return user;
        }

         //Take the User associated with a specified userID and return a User class - Saxon
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static User UserLoginAttempt(string email)
        {
            User user = new User();
            string sql = "SELECT userId, email, firstName, lastName, password, active FROM userInfo WHERE email = @email";

            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    
                    cmd.Parameters.AddWithValue("email", email);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        user.userId = dr["userId"].ToString();
                        user.email = dr["email"].ToString();
                        user.firstName = dr["firstName"].ToString();
                        user.lastName = dr["lastName"].ToString();
                        user.password = dr["password"].ToString();
                        user.active = dr.GetBoolean(dr.GetOrdinal("active"));
                    }

                    dr.Close();
                }
            }
            return user;
        }


        //Set a user to inactive in the database, returns true if it was successful and false if it was not. - Saxon
        [DataObjectMethod(DataObjectMethodType.Update)]
        public static bool SetUserInactive(string userId)
        {
            string sql = "UPDATE User SET active = 'false' WHERE userId = @userId";
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {

                    try
                    {
                        cmd.Parameters.AddWithValue("userId", userId);
                        con.Open();
	                    cmd.ExecuteNonQuery();
	                    return true;
                    }
                    catch
                    {
                        return false;
                    }


                }
            }
        }


        //Take a User class from the business layer and add it to the database - Saxon
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static int AddUser(User user)

        {
            string sql = "INSERT INTO userInfo VALUES (@userId, @firstName, @lastName, @email, @password, 'true')";

            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("userId", user.userId);
                    cmd.Parameters.AddWithValue("firstName", user.firstName);
                    cmd.Parameters.AddWithValue("lastName", user.lastName);
                    cmd.Parameters.AddWithValue("email", user.email);
                    cmd.Parameters.AddWithValue("password", user.password);

                    con.Open();
                   return cmd.ExecuteNonQuery();
                }
            }

        }


        //Update a User's info by replacing one object's information with a new object
        [DataObjectMethod(DataObjectMethodType.Update)]
        public static int UpdateUser(User currentUser, User newUser)
        {
            string sql = "UPDATE userInfo SET email = @email, firstName = @firstName, lastName = @lastName, password = @password WHERE userId = @currentuserId";
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    //new values
                    cmd.Parameters.AddWithValue("firstName", newUser.firstName);
                    cmd.Parameters.AddWithValue("lastName", newUser.lastName);
                    cmd.Parameters.AddWithValue("email", newUser.email);
                    cmd.Parameters.AddWithValue("password", newUser.password);

                    //original values
                    cmd.Parameters.AddWithValue("@currentuserId", currentUser.userId);

                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        //return the connection string being used in the web config file. - Saxon
        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }


    }
}