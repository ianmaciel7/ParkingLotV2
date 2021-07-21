using CarParking.Models;
using System.Collections.Generic;

namespace CarParking.Repositories
{
    public interface IParkingLotRepository
    {
        Ticket GetTicket(int ticketId);
        IEnumerable<Ticket> AllTicket();
        void InsertTicket(Ticket ticket);
        IEnumerable<ParkingSpace> AllParkingSpaces();
        bool HasAnyEmptyParkingSpaces();
        ParkingSpace GetAnyEmptyParkingSpaces();
        void InsertTicketInParkingSpace(Ticket ticket, ParkingSpace parkingSpace);
        double GetPricePerHour(VehicleType vehicleType);
    }
}