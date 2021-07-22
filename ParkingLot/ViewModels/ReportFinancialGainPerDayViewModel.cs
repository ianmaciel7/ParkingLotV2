using CarParking.Models;
using System.Collections.Generic;

namespace CarParking.ViewModels
{
    public class ReportFinancialGainPerDayViewModel
    {
        public ICollection<FinancialGainPerDayViewModel> ListPaid { get; set; }
        public ICollection<Ticket> ListUnpaid { get; set; }
        public ReportFinancialGainPerDayViewModel()
        {
            ListPaid = new List<FinancialGainPerDayViewModel>();
            ListUnpaid = new List<Ticket>();
        }
    }
}
