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
        //[DataObjectMethod(DataObjectMethodType.Select)]
        //public static IEnumerable GetAllGuests(string eventId)
        //{
        //    SqlConnection con = new SqlConnection(GetConnectionString());
        //    string sql = "SELECT name, email FROM Guest WHERE eventId = @eventId ";
        //    SqlCommand cmd = new SqlCommand(sql, con);
        //    cmd.Parameters.AddWithValue("eventId", eventId);
        //    con.Open();
        //    SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        //    return dr;
        //}

        //Returns the guest list for the specified event as a strongly typed list, I removed the user from the picture here as a guest is already associated with a user through the event so eventId makes more sense - Saxon
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<Guest> GetGuests(string eventId)
        {
            List<Guest> guestList = new List<Guest>();
            string sql = "SELECT name, email, active, eventId FROM Guest WHERE eventId = @eventId ORDER BY name";

            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("eventId", eventId);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    Guest guest;

                    while (dr.Read())
                    {
                        guest = new Guest();
                        guest.name = dr["name"].ToString();
                        guest.email = dr["email"].ToString();
                        guest.eventId = dr["eventId"].ToString();
                        guest.active = dr.GetBoolean(dr.GetOrdinal("active"));
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
            
            public string name { get; set; }
            public string email { get; set; }
            public string eventId { get; set; }
            public string rsvp { get; set; }
            public bool active { get; set; }
        }

        // updates a specific guest entry with a new set of values provided in the form of a guest class - Saxon
        [DataObjectMethod(DataObjectMethodType.Update)]
        public static int UpdateGuestList(Guest original_guest, Guest guest)
        {
            string sql = "UPDATE Guest SET name = @name, email = @email WHERE eventId = @original_eventId AND name = @original_name AND email = @original_email";
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
                    cmd.Parameters.AddWithValue("original_eventId", original_guest.eventId);

                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        //function takes a guest class from the business layer and adds it to the database, slightly out of date - Saxon
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static int AddGuest(Guest guest)

        {
            string sql = "INSERT INTO Guest VALUES (@email, @name, @eventId, 'Not Responded', true)";

            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("name", guest.name);
                    cmd.Parameters.AddWithValue("email", guest.email);
                    cmd.Parameters.AddWithValue("eventId", guest.eventId);

                    con.Open();

                    return cmd.ExecuteNonQuery();
                }
            }


        }


        //Delete a guest row in the database by inserting a guest class from the business layer, we won't be using this instead we will expect that database admin handle proper deletions and instead simply set 'deleted' guests to 'inactive' - Saxon
        //[DataObjectMethod(DataObjectMethodType.Delete)]
        //public static int DeleteGuest(string eventId, Guest guest)
        //{

        //    string sql = "DELETE FROM Guest WHERE userId = " + eventId + " AND email = @email";

        //    using (SqlConnection con = new SqlConnection(GetConnectionString()))
        //    {
        //        using (SqlCommand cmd = new SqlCommand(sql, con))
        //        {
        //            cmd.Parameters.AddWithValue("email", guest.email);

        //            con.Open();
        //            return cmd.ExecuteNonQuery();
        //        }
        //    }

        //}


        // returns the connection string being used in the web config file. - Saxon
        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }

    }

}