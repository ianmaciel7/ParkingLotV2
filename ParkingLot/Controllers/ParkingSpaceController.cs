using CarParking.Exceptions;
using CarParking.Models;
using CarParking.Services;

using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CarParking.Controllers
{
    
   
    public class ParkingSpaceController : ApiController
    {
        private readonly ParkingLotService _parkingLotService;

        public ParkingSpaceController()
        {
            _parkingLotService = new ParkingLotService();
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(_parkingLotService.AllParkingSpaces());
            }
            catch (EmptyListException)
            {
                return Content(HttpStatusCode.NoContent, "Sem conteudo");
            }
            catch (Exception)
            {
                return Content(HttpStatusCode.BadRequest, "Database Failure");
            }
        }

        [HttpPatch()]
        public IHttpActionResult Patch([FromUri]int ticketId)
        {
            try
            {
                _parkingLotService.RemoveTicketFromParkingSpace(ticketId);
                return Ok();
            }
            catch (TicketNotFoundException ex)
            {
                return Content(HttpStatusCode.NoContent, ex.Message);
            }
            catch (Exception)
            {
                return Content(HttpStatusCode.BadRequest, "Database Failure");
            }
        }



    }
}
