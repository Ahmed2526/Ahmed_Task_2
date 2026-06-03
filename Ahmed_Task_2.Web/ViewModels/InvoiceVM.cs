using Ahmed_Task_2.Web.ViewModels.FormVM;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ahmed_Task_2.Web.ViewModels
{
    public class InvoiceVM
    {
        public DateOnly DateIssued { get; set; }
        public string InternalId { get; set; }
        public int ActivityCode { get; set; }
        public decimal NetAmount { get; set; }
        public decimal TotalAmount { get; set; }

        public IssuerVM Issuer { get; set; }
        public ReceiverVM Receiver { get; set; }

        public List<InvoiceLineVM> Lines { get; set; }
    }
}
