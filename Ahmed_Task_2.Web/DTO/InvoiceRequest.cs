using Ahmed_Task_2.Web.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Ahmed_Task_2.Web.DTO
{
    public class InvoiceRequest
    {
        public DateOnly DateIssued { get; set; }

        public string InternalId { get; set; }

        public int ActivityCode { get; set; }

        public IssuerRequest Issuer { get; set; }
        public ReceiverRequest Receiver { get; set; }

        public List<InvoiceLineRequest> Lines { get; set; }
    }
}
