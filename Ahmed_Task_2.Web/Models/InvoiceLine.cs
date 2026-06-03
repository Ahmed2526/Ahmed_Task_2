namespace Ahmed_Task_2.Web.Models
{
    public class InvoiceLine
    {
        public int Id { get; set; }

        public int InvoiceId { get; set; }

        public string ItemCode { get; set; }

        public string Description { get; set; }

        public decimal Quantity { get; set; }

        public UnitType UnitType { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal SalesTotal { get; set; }

        public decimal DiscountPerUnit { get; set; }
        public decimal DiscountPercentage { get; set; }

        public decimal TotalTaxableFees { get; set; }
        public decimal NetTotal { get; set; }

        public ICollection<InvoiceTax> Taxes { get; set; }
    }
}
