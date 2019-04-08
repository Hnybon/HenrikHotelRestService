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
    public class FacilityController : ApiController
    {
        ManageFacility mngFacility = new ManageFacility();

        // GET: api/Facility
        public IEnumerable<Facilities> Get()
        {
            return mngFacility.GetAllFacilities();
        }

        // GET: api/Facility/5
        [Route("api/Facility/{HotelNr}")]
        public Facilities Get(int hotelNr)
        {
            return mngFacility.GetFacilityFromHotel(hotelNr);
        }

        // POST: api/Facility
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Facility/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Facility/5
        public void Delete(int id)
        {
        }
    }
}
