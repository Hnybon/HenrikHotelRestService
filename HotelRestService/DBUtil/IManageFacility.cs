using System.Collections.Generic;
using HotelModels;

namespace HotelRestService.DBUtil
{
    public interface IManageFacility
    {
        List<Facilities> GetAllFacilities();
        Facilities GetFacilityFromHotel(int hotelNr);
        bool CreateFacility(Facilities newFacility);
        bool UpdateFacility(Facilities facility, int id, int hotel, int hotelNr, string facilityId);
        Facilities DeleteFacility(int id, int hotel);
    }
}