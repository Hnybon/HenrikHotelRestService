using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using HotelModels;

namespace HotelRestService.DBUtil
{
    public class ManageFacility: IManageFacility
    {

        ConnectionString c = new ConnectionString();
        Facilities facility = new Facilities();

        #region GetAll
        public List<Facilities> GetAllFacilities()
        {
            List<Facilities> facilityList = new List<Facilities>();

            string queryString = "SELECT * FROM FacilityList";
            using (SqlConnection connection = new SqlConnection(c.ConnectString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {

                        facility.FacilityId = reader.GetInt32(0);
                        facility.HotelNr = reader.GetInt32(1);
                        facilityList.Add(facility);
                    }
                }
                finally
                {
                    reader.Close();
                }
                return facilityList;
            }
        }

        
        #endregion

        #region GetFromHotel
        public Facilities GetFacilityFromHotel(int hotelNr)
        {

            string queryString = "SELECT * FROM FacilityList WHERE Hotel_No =" + hotelNr;
            using (SqlConnection connection = new SqlConnection(c.ConnectString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {

                        facility.FacilityId = reader.GetInt32(0);
                        facility.HotelNr = reader.GetInt32(1);
                    }
                }
                finally
                {
                    //Lukker read når den er færdig med at læse informationerne.
                    reader.Close();
                }

                return facility;
            }
        }
        #endregion

        #region Create
        public bool CreateFacility(Facilities newFacility)
        {
            string queryString = "INSERT into FacilityList (Hotel_No, FacilityId)" +
                                 "VALUES ('" + newFacility.HotelNr + "'" +
                                 ", " + "'" + newFacility.FacilityId + "')";
            using (SqlConnection connection = new SqlConnection(c.ConnectString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        newFacility.FacilityId = reader.GetInt32(0);
                        newFacility.HotelNr = reader.GetInt32(1);
                        
                    }
                }
                finally
                {
                    //Lukker read når den er færdig med at læse informationerne.
                    reader.Close();
                }

                return true;
            }
        }
        #endregion

        #region Update
        public bool UpdateFacility(Facilities facility, int id, int hotel, int hotelNr, string facilityId)
        {
            string queryString = "Update FacilityList " +
                                 "SET  Hotel_No='" + facility.HotelNr + "', FacilityId ='" + facility.FacilityId + "' " +
                                 "WHERE FacilityId= " + id + " AND Hotel_No = " + hotel;

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
        public Facilities DeleteFacility(int id, int hotel)
        {
            string queryString = "DELETE FROM DemoFacility WHERE FacilityId =" + id + "AND Hotel_No =" + hotel;
            using (SqlConnection connection = new SqlConnection(c.ConnectString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
                command.Connection.Close();
            }
            return facility;
        }
        #endregion
    }
}