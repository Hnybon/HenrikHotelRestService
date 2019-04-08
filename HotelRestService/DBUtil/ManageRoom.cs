using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using HotelModels;

namespace HotelRestService.DBUtil
{
    public class ManageRoom : IManageRoom
    {

        ConnectionString c = new ConnectionString();
        
        public List<Room> GetAllRooms()
        {
            
            List<Room> roomList = new List<Room>();

            string queryString = "SELECT * FROM DemoRoom"; //Vælger alt fra DemoRoom tabellen.
            using (SqlConnection connection = new SqlConnection(c.ConnectString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        Room room = new Room();
                        room.Room_No = reader.GetInt32(0);
                        room.Hotel_No = reader.GetInt32(1);
                        room.Types = reader.GetString(2);
                        room.Price = reader.GetDouble(3);
                        roomList.Add(room);
                    }                  
                }
                finally
                {
                    //Lukker read når den er færdig med at læse informationerne.
                    reader.Close();
                }
                return roomList;
            }
        }

        public Room GetRoomFromId(int roomNr, int hotelNr)
        {
            Room room = new Room();
            string queryString = "SELECT * FROM DemoRoom WHERE Room_No =" + roomNr + "AND Hotel_No=" + hotelNr;
            using (SqlConnection connection = new SqlConnection(c.ConnectString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {  
                        room.Room_No = reader.GetInt32(0);
                        room.Hotel_No = reader.GetInt32(1);
                        room.Types = reader.GetString(2);
                        room.Price = reader.GetDouble(3);
                    }
                }
                finally
                {
                    reader.Close();
                }
                return room;
            }
        }

        public bool CreateRoom(Room room)
        {
            string queryString = "INSERT into DemoRoom (Room_No, Hotel_No, Types, Price)" +
                                 "VALUES " + "(" + "'" + room.Room_No + "',"  + "'" + room.Hotel_No + "'" + 
                                 ", " + "'" + room.Types + "'" + "," + "'" + room.Price + "'" + ")";
                     
            using (SqlConnection connection = new SqlConnection(c.ConnectString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
                command.Connection.Close();                  
            }
            return true;
        }

        public bool UpdateRoom(Room room, int roomNr, int hotelNr)
        {
            string queryString = "Update DemoRoom " +
                                 "SET Room_No=" + room.Room_No + ", Hotel_No='" + room.Hotel_No + "', Types='" + room.Types + "' " + ", Price='" + room.Price + "' " +
                                 "WHERE Room_No=" + roomNr + "AND Hotel_No=" + hotelNr;                
            using (SqlConnection connection = new SqlConnection(c.ConnectString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
                command.Connection.Close();                  
            }
            return true;
        }

        public Room DeleteRoom(int roomNr, int hotelNr)
        {
            Room room = new Room();
            string queryString = "DELETE FROM DemoRoom WHERE Room_No =" +roomNr + "AND Hotel_No=" + hotelNr;
            using (SqlConnection connection = new SqlConnection(c.ConnectString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
                command.Connection.Close();                                      
            }
            return room;
        }
    }
}