using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelModels;

namespace HotelRestService.DBUtil
{
    interface IManageRoom
    {
        List<Room> GetAllRooms();
        Room GetRoomFromId(int roomNr, int hotelNr);
        bool CreateRoom(Room room);
        bool UpdateRoom(Room room, int roomNr, int hotelNr);
        Room DeleteRoom(int roomNr, int hotelNr);
    }
}
