using System.Collections.Generic;
using System.Data.SqlClient;
using HotelModels;

namespace HotelRestService.DBUtil
{
    public class ManageHotel : IManageHotel
    {
        ConnectionString c = new ConnectionString();
        Hotel hotel = new Hotel();

        public List<Hotel> GetAllRooms()
        {
            List<Hotel> hotelList = new List<Hotel>();
            
            string queryString = "SELECT * FROM DemoHotel"; //Vælger alt fra DemoHotel tabellen.
            using (SqlConnection connection = new SqlConnection(c.ConnectString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        
                        hotel.Hotel_No = reader.GetInt32(0);
                        hotel.Name = reader.GetString(1);
                        hotel.Address = reader.GetString(2);
                        hotelList.Add(hotel);
                    }
                }
                finally
                {
                    //Lukker read når den er færdig med at læse informationerne.
                    reader.Close();
                }
                return hotelList;
            }
        }

        public Hotel GetHotelFromId(int hotelNr)
        {
            string queryString = "SELECT * FROM DemoHotel WHERE Hotel_No =" + hotelNr;
            using (SqlConnection connection = new SqlConnection(c.ConnectString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        hotel.Hotel_No = reader.GetInt32(0);
                        hotel.Name = reader.GetString(1);
                        hotel.Address = reader.GetString(2);
                    }
                }
                finally
                {
                    reader.Close();
                }
                return hotel;
            }
        }

        public Hotel GetHotelFromName(int hotelName)
        {
            string queryString = "SELECT * FROM DemoHotel WHERE Name =" + hotelName;
            using (SqlConnection connection = new SqlConnection(c.ConnectString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        hotel.Hotel_No = reader.GetInt32(0);
                        hotel.Name = reader.GetString(1);
                        hotel.Address = reader.GetString(2);
                    }
                }
                finally
                {
                    reader.Close();
                }
                return hotel;
            }
        }

        public Hotel GetHotelFromAddress(int hotelAddress)
        {
            string queryString = "SELECT * FROM DemoHotel WHERE Address =" + hotelAddress;
            using (SqlConnection connection = new SqlConnection(c.ConnectString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        hotel.Hotel_No = reader.GetInt32(0);
                        hotel.Name = reader.GetString(1);
                        hotel.Address = reader.GetString(2);
                    }
                }
                finally
                {
                    reader.Close();
                }
                return hotel;
            }
        }

        public bool CreateHotel(Hotel hotel)
        {
            string queryString = "INSERT into DemoHotel (Hotel_No, Name, Address)" +
                                 "VALUES " + "('" + hotel.Hotel_No + "', '" + hotel.Name + "'" +
                                 ", '" + hotel.Address + "')";

            using (SqlConnection connection = new SqlConnection(c.ConnectString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
                command.Connection.Close();
            }
            return true;
        }

        public bool UpdateHotel(Hotel hotel, int hotelNr, string hotelName, string hotelAddress)
        {
            string queryString = "Update DemoHotel " +
                                 "SET Hotel_No='" + hotelNr + "', Name='" + hotelName + "', Address='" + hotelAddress + "' " +
                                 "WHERE Hotel_No=" + hotelNr;
            using (SqlConnection connection = new SqlConnection(c.ConnectString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
                command.Connection.Close();
            }
            return true;
        }

        public Hotel DeleteHotel(int hotelNr)
        {
            string queryString = "DELETE FROM DemoHotel WHERE Hotel_No=" + hotelNr;
            using (SqlConnection connection = new SqlConnection(c.ConnectString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
                command.Connection.Close();                                      
            }
            return hotel;
        }
        
    }
}