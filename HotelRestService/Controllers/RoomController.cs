using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HotelModels;
using HotelRestService.DBUtil;

namespace HotelRestService.Controllers
{
    public class RoomController : ApiController
    {
        // GET: api/Room
        public IEnumerable<Room> Get()
        {
            ManageRoom mngRoom = new ManageRoom();
            return mngRoom.GetAllRooms();
        }
        
        // GET: api/Room/roomNr/hotelNr
        [Route("api/Room/{Room_No}/{Hotel_No}")]
        public Room Get(int Room_No, int Hotel_No)
        {
            ManageRoom mngRoom = new ManageRoom();
            return mngRoom.GetRoomFromId(Room_No, Hotel_No);
        }

        // POST: api/Room
        public void Post([FromBody]Room value)
        {
            ManageRoom mngRoom = new ManageRoom();
            mngRoom.CreateRoom(value);
        }

        // GET: api/Room/roomNr/hotelNr
        [Route("api/Room/{Room_No}/{Hotel_No}")]
        public void Put(int Room_No, int Hotel_No, [FromBody]Room value)
        {
            ManageRoom mngRoom = new ManageRoom();
            mngRoom.UpdateRoom(value, Room_No, Hotel_No);
        }

        // GET: api/Room/roomNr/hotelNr
        [Route("api/Room/{Room_No}/{Hotel_No}")]
        public void Delete(int Room_No, int Hotel_No)
        {
            ManageRoom mngRoom = new ManageRoom();
            mngRoom.DeleteRoom(Room_No, Hotel_No);
        }
    }
}
