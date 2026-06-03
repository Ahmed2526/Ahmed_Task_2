using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ahmed_Task_2.Web.ViewModels
{
    public class InvoiceTaxVM
    {
        public string TaxType { get; set; }
        public string TaxSubType { get; set; }

        public decimal Rate { get; set; }
        public decimal Amount { get; set; }
    }
}
