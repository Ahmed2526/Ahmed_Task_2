using Ahmed_Task_2.Web.CustomAttributes;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Ahmed_Task_2.Web.DTO
{
    public class InvoiceTaxRequest
    {
        public int TaxType { get; set; }
        public int TaxSubType { get; set; }

        [Range(0.00001, 999999999999.99999)]
        [DecimalPrecision(5)]
        public decimal Rate { get; set; }

        [Range(0.00001, 999999999999.99999)]
        [DecimalPrecision(5)]
        public decimal Amount { get; set; }
    }
}
