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

    //Data Access required for a user viewing their events, needs to access the events associated with a user and the steps associated with those events. - Saxon

    [DataObject(true)]
    public class EventDataAccess
    {

        //the Event class mirrors a row in the Event data table - Saxon
        public class Event
        {

            public string eventId;
            public string Name;
            public string Description;
            public string userId;

        }

        //the Step class mirrors a row in the Step data table - Saxon
        public class Step
        {
            public string stepId;
            public string Name;
            public string actualStart;
            public string actualCompletion;
            public string actualCost;
            public string eventId;
        }


        //Function for taking the Events associated with a specified user and returning a strongly typed list of Event classes - Saxon
        public static List<Event> GetEvents(string userId)
        {
            List<Event> eventList = new List<Event>();
            string sql = "SELECT eventId, Name, Description FROM Event WHERE userId = @userId ORDER BY Name";

            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    //need to name an individual event singleEvent to prevent errors -Saxon
                    Event singleEvent;

                    while (dr.Read())
                    {

                        singleEvent = new Event();
                        singleEvent.eventId = dr["eventId"].ToString();
                        singleEvent.Name = dr["Name"].ToString();
                        singleEvent.Description = dr["Description"].ToString();
                        singleEvent.userId = dr["userId"].ToString();
                        eventList.Add(singleEvent);

                    }
                    dr.Close();
                }
            }
            return eventList;
        }

        //Function for taking the Steps associated with a specified event and returning a strongly typed list of Step classes - Saxon
        public static List<Step> GetSteps(string eventId)
        {
            List<Step> stepList = new List<Step>();
            string sql = "SELECT stepId, Name, actualStart, actualCompletion, actualCost FROM Step WHERE eventId = @eventId ORDER BY actualCompletion";

            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    //need to name an individual event singleEvent to prevent errors -Saxon
                    Step step;

                    while (dr.Read())
                    {

                        step = new Step();
                        step.eventId = dr["eventId"].ToString();
                        step.Name = dr["Name"].ToString();
                        step.actualStart = dr["actualStart"].ToString();
                        step.actualCompletion = dr["actualCompletion"].ToString();
                        step.actualCost = dr["actualCost"].ToString();
                        stepList.Add(step);

                    }
                    dr.Close();
                }
            }
            return stepList;
        }

        //Function for updating a specific Event - Saxon

        //Function for updating a specific Step - Saxon


        //Function for adding a Step to an Event - Saxon

        //Function for a adding an Event to a User - Saxon


        // Function for removing an Event - Saxon

        // Function for removing a Step - Saxon

        // returns the connection string being used in the web config file. - Saxon
        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }


    }
}