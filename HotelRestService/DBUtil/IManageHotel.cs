using System.Collections.Generic;
using HotelModels;

namespace HotelRestService.DBUtil
{
    public interface IManageHotel
    {
        List<Hotel> GetAllRooms();
        Hotel GetHotelFromId(int hotelNr);
        Hotel GetHotelFromName(int hotelName);
        Hotel GetHotelFromAddress(int hotelAddress);
        bool CreateHotel(Hotel hotel);
        bool UpdateHotel(Hotel hotel, int hotelNr, string hotelName, string hotelAddress);
        Hotel DeleteHotel(int hotelNr);
    }
}