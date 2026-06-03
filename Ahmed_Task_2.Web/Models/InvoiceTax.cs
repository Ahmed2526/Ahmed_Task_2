using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ahmed_Task_2.Web.Models
{
    public class InvoiceTax
    {
        public int Id { get; set; }


        [ForeignKey(nameof(InvoiceLine))]
        public int InvoiceLineId { get; set; }
        public InvoiceLine InvoiceLine { get; set; }


        [ForeignKey(nameof(TaxType))]
        public int TaxTypeId { get; set; }
        public TaxType TaxType { get; set; }


        [ForeignKey(nameof(TaxSubType))]
        public int TaxSubTypeId { get; set; }
        public TaxSubType TaxSubType { get; set; }


        public decimal Rate { get; set; }
        public decimal Amount { get; set; }
    }
}
