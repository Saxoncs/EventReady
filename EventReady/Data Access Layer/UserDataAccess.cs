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

        //Function for taking the Users associated with a specified userID and returning a user class - Saxon
        public static User GetUser(string userId)
        {
            User user = new User();
            string sql = "SELECT userId, email, firstName, lastName, password, active FROM userInfo WHERE userId = @userId";

            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
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

        // returns the connection string being used in the web config file. - Saxon
        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }


    }
}