using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DemoHotelDB.DBUtil;
using HotelModels;

namespace HotelRestService.DBUtil
{
    public class ManageGuest :IManageGuest
    {

       ConnectionString c = new ConnectionString();


        #region GetAll
        /// <summary>
        /// Finder alle DemoGuest i tabellen.
        /// </summary>
        /// <returns></returns>
        public List<Guest> GetAllGuest()
        {
            List<Guest> guestList = new List<Guest>();

            string queryString = "SELECT * FROM DemoGuest"; //Vælger alt fra DemoGuest tabellen.
            using (SqlConnection connection = new SqlConnection(c.ConnectString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        Guest guest = new Guest();
                        guest.Guest_No = reader.GetInt32(0);
                        guest.Name = reader.GetString(1);
                        guest.Address = reader.GetString(2);
                        guestList.Add(guest);
                    }                  
                }
                finally
                {
                    //Lukker read når den er færdig med at læse informationerne.
                    reader.Close();
                }
                return guestList;
            }
        }
        #endregion

        #region GetFromId

        /// <summary>
        /// Finder en DemoGuest ud fra Guest_No.
        /// </summary>
        /// <param name="guestNr"></param>
        /// <returns></returns>
        public Guest GetGuestFromId(int guestNr)
        {
            Guest guest = new Guest();
            string queryString = "SELECT * FROM DemoGuest WHERE Guest_No =" +guestNr;
            using (SqlConnection connection = new SqlConnection(c.ConnectString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        guest.Guest_No = reader.GetInt32(0);
                        guest.Name = reader.GetString(1);
                        guest.Address = reader.GetString(2);
                    }
                }
                finally
                {
                    reader.Close();
                }
                return guest;
            }
        }
        #endregion

        #region Create

        /// <summary>
        /// Laver en DemoGuest med et Guest_No, Guest_Address og Guest_Name.
        /// </summary>
        /// <param name="guest"></param>
        /// <returns></returns>
        public bool CreateGuest(Guest guest)
        {

            string queryString = "INSERT into DemoGuest (Guest_No, Name, Address)" +
                                 "VALUES " + "(" + "'" + guest.Guest_No + "',"  + "'" + guest.Name + "'" + 
                                 ", " + "'" + guest.Address + "'" + ")";
                     
                using (SqlConnection connection = new SqlConnection(c.ConnectString))
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();                  
                }
            return true;
        }
        #endregion

        #region Update
        /// <summary>
        /// Opdaterer en gæst, som er valgt fra Guest_No.
        /// </summary>
        /// <param name="guest"></param>
        /// <param name="guestNr"></param>
        /// <returns></returns>
        public bool UpdateGuest(Guest guest, int guestNr)
        {
            string queryString = "Update DemoGuest " +
                                 "SET Guest_No=" + guestNr + ", Name='" + guest.Name + "', Address='" + guest.Address + "' " +
                                 "WHERE Guest_No=" + guestNr;
                     
            using (SqlConnection connection = new SqlConnection(c.ConnectString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
                command.Connection.Close();                  
            }
            return true;
        }
        #endregion

        #region Delete
        /// <summary>
        /// Sletter en specifik Gæst ud fra et Guest_No.
        /// </summary>
        /// <param name="guestNr"></param>
        /// <returns></returns>
        public Guest DeleteGuest(int guestNr)
        {
            Guest guest = new Guest();
            string queryString = "DELETE FROM DemoGuest WHERE Guest_No =" +guestNr;
            using (SqlConnection connection = new SqlConnection(c.ConnectString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
                command.Connection.Close();                                      
            }
            return guest;
        }
        #endregion
    }
}