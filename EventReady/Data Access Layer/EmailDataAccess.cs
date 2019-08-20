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
    //Converts the information stored within the database into a class that is usable by the site. Needs to access and update the logged in user's guest list - Saxon

    [DataObject(true)]
    public class EmailDataAccess
    {

        // Reads Guest data from the database in regards to specified user (just add the user's Id as an argument) may be superseded by following function - Saxon
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static IEnumerable GetAllGuests(string userId)
        {
            SqlConnection con = new SqlConnection(GetConnectionString());
            string sql = "SELECT name, email FROM Guest WHERE userId = @userId ";
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return dr;
        }

        //Returns the guest list for the specified user as a strongly typed list - Saxon
        public static List<Guest> GetGuests(string userId)
        {
            List<Guest> guestList = new List<Guest>();
            string sql = "SELECT name, email, userId FROM Guest WHERE userId = @userId ORDER BY name";

            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    Guest guest;

                    while (dr.Read())
                    {
                        guest = new Guest();
                        guest.name = dr["name"].ToString();
                        guest.email = dr["email"].ToString();
                        guest.userId = dr["userId"].ToString();
                        guestList.Add(guest);

                    }
                    dr.Close();
                }
            }
            return guestList;
        }

        //the guest class that is mirrors a row in the Guest data table - Saxon
        public class Guest
        {
            public string name;
            public string email;
            public string userId;
        }

        // updates a specific guest entry with a new set of values provided in the form of a guest class - Saxon
        [DataObjectMethod(DataObjectMethodType.Update)]
        public static int UpdateGuestList(Guest original_guest, Guest guest)
        {
            string sql = "UPDATE Guest SET name = @name, email = @email WHERE userId = @original_userId AND name = @original_name AND email = @original_email";
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    //new values
                    cmd.Parameters.AddWithValue("name", guest.name);
                    cmd.Parameters.AddWithValue("email", guest.email);

                    //original values
                    cmd.Parameters.AddWithValue("original_name", original_guest.name);
                    cmd.Parameters.AddWithValue("original_email", original_guest.email);
                    cmd.Parameters.AddWithValue("original_userId", original_guest.userId);

                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        //adds a guest to the database under specified userId, will add an overload for both a class entry and a string entry just to make things easier. - Saxon
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public IEnumerable AddGuest(string userId, string name, string )
        {
            return null;

        }

        //overloaded function takes a guest class instead of an individual string, probably more useful - Saxon
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public IEnumerable AddGuest(string userId, Guest guest)
        {
            return null;

        }

        //Deletes a guest, also contains an overloaded option - Saxon
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public IEnumerable DeleteGuest(string userId, string email)
        {
            return null;

        }

        //Delete a guest by inserting a guest class instead - Saxon
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public IEnumerable DeleteGuest(string userId, Guest guest)
        {
            return null;

        }




        // returns the connection string being used in the web config file. - Saxon
        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }

    }

}