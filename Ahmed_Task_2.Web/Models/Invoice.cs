using System.ComponentModel.DataAnnotations.Schema;

namespace Ahmed_Task_2.Web.Models
{
    public class Invoice
    {
        public int Id { get; set; }

        public string InternalId { get; set; }

        public DateOnly DateIssued { get; set; }

        [ForeignKey(nameof(ActivityCode))]
        public int ActivityCodeId { get; set; }
        public ActivityCode ActivityCode { get; set; }

        [ForeignKey(nameof(Issuer))]
        public int IssuerId { get; set; }
        public InvoiceParty Issuer { get; set; }

        [ForeignKey(nameof(Receiver))]
        public int ReceiverId { get; set; }
        public InvoiceParty Receiver { get; set; }

        public ICollection<InvoiceLine> Lines { get; set; } = new List<InvoiceLine>();

        public decimal NetAmount { get; set; }
        public decimal TotalAmount { get; set; }

    }
}
