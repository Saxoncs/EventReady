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

            public string eventId { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public int daysDelayed { get; set; }
            public DateTime start { get; set; }
            public DateTime deadline { get; set; }
            public string userId { get; set; }

        }

        //the Step class mirrors a row in the Step data table - Saxon
        public class Step
        {
            public string stepId { get; set; }
            public string name { get; set; }
            public string predictedCompletion { get; set; }
            public string actualCompletion { get; set; }
            public string predictedCost { get; set; }
            public string actualCost { get; set; }
            public string eventId { get; set; }
        }


        //Function for taking the Events associated with a specified user and returning a strongly typed list of Event classes - Saxon
        public static List<Event> GetEvents(string userId)
        {
            List<Event> eventList = new List<Event>();
            string sql = "SELECT eventId, name, description, daysDelayed, start, deadline FROM Event WHERE userId = @userId ORDER BY Name";

            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    //need to name an individual event singleEvent to prevent errors -Saxon
                    Event singleEvent;

                    //I need to look up how to change values into not strings... it's possible that you just store the values as strings for now then change them later but that seems odd -Saxon
                    while (dr.Read())
                    {

                        singleEvent = new Event();
                        singleEvent.eventId = dr["eventId"].ToString();
                        singleEvent.name = dr["name"].ToString();
                        singleEvent.description = dr["description"].ToString();
                        singleEvent.userId = dr["userId"].ToString();
                        //singleEvent.daysDelayed = dr["daysDelayed"];
                        //singleEvent.start = dr["start"];
                        //singleEvent.deadline = dr["deadline"];
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
            string sql = "SELECT stepId, name, predictedCompletion, actualCompletion, predictedCost, actualCost FROM Step WHERE eventId = @eventId ORDER BY predictedCompletion";

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
                        step.stepId = dr["stepId"].ToString();
                        step.name = dr["Name"].ToString();
                        step.actualCost = dr["actualCost"].ToString();
                        step.actualCompletion = dr["actualCompletion"].ToString();
                        step.predictedCost = dr["predictedCost"].ToString();
                        step.predictedCompletion = dr["predictedCompletion"].ToString();
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