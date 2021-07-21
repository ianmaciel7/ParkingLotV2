using CarParking.Services;
using CarParking.ViewModels;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace CarParking.Controllers
{
    
    public class ReportController : ApiController
    {
        private readonly ParkingLotService _parkingLotService;

        public ReportController(ParkingLotService parkingLotService)
        {
            _parkingLotService = parkingLotService;

        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var totalSoldPerDay = _parkingLotService.TotalSoldPerDay();
            if (totalSoldPerDay == null) return Content(HttpStatusCode.NoContent, "Sem conteudo");
            return Ok(totalSoldPerDay);
        }
    }
}
