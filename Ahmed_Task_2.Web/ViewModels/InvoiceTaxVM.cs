using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ahmed_Task_2.Web.ViewModels
{
    public class InvoiceTaxVM
    {
        public int TaxType { get; set; }
        public int TaxSubType { get; set; }
        public List<SelectListItem>? TaxTypesList { get; set; }
        public List<SelectListItem>? TaxSubTypeList { get; set; }

        public decimal Rate { get; set; }
        public decimal Amount { get; set; }
    }
}
