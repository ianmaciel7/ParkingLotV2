using CarParking.Models;
using CarParking.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarParking.Services
{
    public interface IParkingLotService
    {
         Task<Ticket> GetTicket(int ticketId);
         Task<IEnumerable<Ticket>> AllTicket();
         Ticket InsertTicket(TicketInputModel model);
         Task<IEnumerable<ParkingSpace>> AllParkingSpaces();
         ReportFinancialGainPerDayViewModel TotalSoldPerDay();
         Ticket UpdatePaymentStatusInTicket(int ticketId);
         void RemoveTicketFromParkingSpace(int ticketId);
    }
}
