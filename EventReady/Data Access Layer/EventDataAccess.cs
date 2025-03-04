﻿using System;
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
            public bool active { get; set; }
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
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<Event> GetEvents(string userId)
        {
            List<Event> eventList = new List<Event>();
            string sql = "SELECT eventId, name, description, daysDelayed, start, deadline, active, userId FROM Event WHERE userId = @userId ORDER BY deadline";

            //try to read a connection from database
            try
            {
                using (SqlConnection con = new SqlConnection(GetConnectionString()))
	            {
	                using (SqlCommand cmd = new SqlCommand(sql, con))
	                {
                        cmd.Parameters.AddWithValue("userId", userId);
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
                            singleEvent.daysDelayed = dr.GetInt16(dr.GetOrdinal("daysDelayed"));
                            singleEvent.start = dr.GetDateTime(dr.GetOrdinal("start"));
                            singleEvent.deadline = dr.GetDateTime(dr.GetOrdinal("deadline"));
                            singleEvent.active = dr.GetBoolean(dr.GetOrdinal("active"));
                            singleEvent.userId = dr["userId"].ToString();
	                        eventList.Add(singleEvent);
	
	                    }
	                    dr.Close();
	                }
	            }
	            return eventList;
            }
            catch
            {
                throw new Exception("Unable to access Event table in the database");
            }
        }

        //Function for taking the Steps associated with a specified event and returning a strongly typed list of Step classes - Saxon
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<Step> GetSteps(string eventId)
        {
            List<Step> stepList = new List<Step>();
            string sql = "SELECT stepId, name, predictedCompletion, actualCompletion, predictedCost, actualCost FROM Step WHERE eventId = @eventId ORDER BY predictedCompletion";

            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("eventId", eventId);
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

        //Function for a adding an Event to a User - Saxon


        // Function for removing an Event returns true if successful and false if not - Saxon
        [DataObjectMethod(DataObjectMethodType.Update)]
        public static bool SetEventInactive(string eventId)
        {
            string sql = "UPDATE Event SET active = 'false' WHERE eventId = @eventId";
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("eventId", eventId);

                    try
                    {
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

        // Function for editing an Event returns true if successful and false if not - Saxon
        [DataObjectMethod(DataObjectMethodType.Update)]
        public static int UpdateEvent(string currentEventId, Event newEvent)
        {
            string sql = "UPDATE Event SET name = @name, start = @start, description = @description, deadline = @deadline, daysDelayed = @daysDelayed WHERE eventId = @currenteventId";
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    //new values
                    cmd.Parameters.AddWithValue("name", newEvent.name);
                    cmd.Parameters.AddWithValue("eventId", newEvent.eventId);
                    cmd.Parameters.AddWithValue("start", newEvent.start);
                    cmd.Parameters.AddWithValue("description", newEvent.description);
                    cmd.Parameters.AddWithValue("deadline", newEvent.deadline);
                    cmd.Parameters.AddWithValue("daysDelayed", newEvent.daysDelayed);

                    //original values
                    cmd.Parameters.AddWithValue("@currenteventId", currentEventId);

                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        //Take an Event class from the business layer and add it to the database, there is no need to worry about adding id's as they are identity fields in the database - Saxon
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static int AddEvent(Event eventInfo)
        {
            string sql = "INSERT INTO Event VALUES (@name, @description, 0, @start, @deadline, @userId, 'true')";

            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("name", eventInfo.name);
                    cmd.Parameters.AddWithValue("description", eventInfo.description);
                    cmd.Parameters.AddWithValue("start", eventInfo.start);
                    cmd.Parameters.AddWithValue("deadline", eventInfo.deadline);
                    cmd.Parameters.AddWithValue("userId", eventInfo.userId);
                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }

        }



        //Function for taking the Events associated with a specified user and returning a strongly typed list of Event classes - Saxon
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Event GetEvent(string eventId)
        {
            string sql = "SELECT eventId, name, description, daysDelayed, start, deadline, active, userId FROM Event WHERE eventId = @eventId";
            Event singleEvent = new Event();
            //try to read a connection from database
            try
            {
                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("eventId", eventId);
                        con.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        //need to name an individual event singleEvent to prevent errors -Saxon

                        //I need to look up how to change values into not strings... it's possible that you just store the values as strings for now then change them later but that seems odd -Saxon
                        while (dr.Read())
                        {

                            singleEvent.eventId = dr["eventId"].ToString();
                            singleEvent.name = dr["name"].ToString();
                            singleEvent.description = dr["description"].ToString();
                            singleEvent.daysDelayed = dr.GetInt16(dr.GetOrdinal("daysDelayed"));
                            singleEvent.start = dr.GetDateTime(dr.GetOrdinal("start"));
                            singleEvent.deadline = dr.GetDateTime(dr.GetOrdinal("deadline"));
                            singleEvent.active = dr.GetBoolean(dr.GetOrdinal("active"));
                            singleEvent.userId = dr["userId"].ToString();

                        }
                        dr.Close();
                    }
                }
                return singleEvent;
            }
            catch
            {
                throw new Exception("Unable to access Event table in the database");
            }
        }




        // Function for removing a Step - Saxon

        // returns the connection string being used in the web config file. - Saxon
        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }




    }
}