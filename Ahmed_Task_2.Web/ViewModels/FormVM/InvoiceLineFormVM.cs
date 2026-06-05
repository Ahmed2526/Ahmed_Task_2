using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Ahmed_Task_2.Web.ViewModels.FormVM
{
    public class InvoiceLineFormVM
    {
        public string ItemCode { get; set; }
        public string Description { get; set; }
        public decimal Quantity { get; set; }

        [Display(Name = "Unit Type")]
        public int UnitTypeId { get; set; }
        public List<SelectListItem>? UnitTypesList { get; set; } = new();

        [Display(Name = "Unit Price")]
        public decimal UnitPrice { get; set; }


        [Display(Name = "Discount/Unit")]
        public decimal DiscountPerUnit { get; set; }

        [Display(Name = "Discount Percentage")]
        public decimal DiscountPercentage { get; set; }

        public List<InvoiceTaxFormVM>? Taxes { get; set; } = new();
    }
}
