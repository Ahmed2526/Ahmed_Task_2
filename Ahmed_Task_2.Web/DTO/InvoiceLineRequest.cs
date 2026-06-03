using Ahmed_Task_2.Web.CustomAttributes;
using Ahmed_Task_2.Web.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Ahmed_Task_2.Web.DTO
{
    public class InvoiceLineRequest
    {
        public string ItemCode { get; set; }
        public string Description { get; set; }


        [Range(0.00001, 999999999999.99999)]
        [DecimalPrecision(5)]
        public decimal Quantity { get; set; }
        public int UnitTypeId { get; set; }


        [Range(0.00001, 999999999999.99999)]
        [DecimalPrecision(5)]
        public decimal UnitPrice { get; set; }


        [Range(0.00001, 999999999999.99999)]
        [DecimalPrecision(5)]
        public decimal DiscountPerUnit { get; set; }

        [Range(0.00001, 999999999999.99999)]
        [DecimalPrecision(5)]
        public decimal DiscountPercentage { get; set; }

        public List<InvoiceTaxRequest>? Taxes { get; set; }
    }
}
