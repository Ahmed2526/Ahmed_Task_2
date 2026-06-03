using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ahmed_Task_2.Web.ViewModels
{
    public class InvoiceLineVM
    {
        public string ItemCode { get; set; }
        public string Description { get; set; }
        public decimal Quantity { get; set; }
        public int UnitTypeId { get; set; }
        public List<SelectListItem>? UnitTypesList { get; set; }

        public decimal UnitPrice { get; set; }
        public decimal SalesTotal { get; set; }
        public decimal DiscountPerUnit { get; set; }
        public decimal DiscountPercentage { get; set; }

        public List<InvoiceTaxVM>? Taxes { get; set; }
    }
}
