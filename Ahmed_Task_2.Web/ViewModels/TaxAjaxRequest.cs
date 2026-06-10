using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ahmed_Task_2.Web.ViewModels
{
    public class TaxAjaxRequest
    {
        public int TaxType { get; set; }
        public int TaxSubType { get; set; }
        public decimal Rate { get; set; }
        public decimal Amount { get; set; }
        public decimal NetTotal { get; set; }
    }
}
