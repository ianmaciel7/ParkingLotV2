using CarParking.Exceptions;
using CarParking.Models;
using CarParking.Services;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace CarParking.Controllers
{
    
    public class TicketController : ApiController
    {
        private readonly ParkingLotService _parkingLotService;
       

        public TicketController()
        {
            _parkingLotService = new ParkingLotService();          
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(_parkingLotService.AllTicket());
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

        [HttpGet]
        public IHttpActionResult Get([FromUri]int ticketId)
        {
            try
            {
                return Ok(_parkingLotService.GetTicket(ticketId).Result);
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

        [HttpPost]
        public IHttpActionResult Post(TicketInputModel model)
        {
            try
            {

                var result = _parkingLotService.InsertTicket(model);
                return Content(HttpStatusCode.Created, result);
               

            }
            catch (InsertFieldLessThanZeroException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InsertNullFieldException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InsertInvalidDateException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InsertInvalidEnumException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ExceededTheLimitException ex)
            {
                return Content(HttpStatusCode.BadRequest, ex.Message);               
            }
            catch (Exception)
            {
                return Content(HttpStatusCode.BadRequest, "Database Failure"); ;
            }
        }

        [HttpPatch]
        public IHttpActionResult Patch([FromUri] int ticketId)
        {
            try
            {
                var result = _parkingLotService.UpdatePaymentStatusInTicket(ticketId);
                return Ok(result);
            }
            catch (TicketNotFoundException ex)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return Content(HttpStatusCode.BadRequest, "Database Failure");
            }
        }
    }
}
