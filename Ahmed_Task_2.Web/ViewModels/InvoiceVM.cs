using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Ahmed_Task_2.Web.ViewModels
{
    public class InvoiceVM
    {
        [Display(Name = "Date Issued")]
        public DateOnly DateIssued { get; set; }

        //handle validation for internal id to be unique in the database
        [Display(Name = "Internal Id")]
        public string InternalId { get; set; }

        //Seed Data for Activity Codes
        [Display(Name = "Activity Code")]   
        public int ActivityCode { get; set; }
        public List<SelectListItem>? ActivityCodeList { get; set; }

        public IssuerVM Issuer { get; set; }
        public ReceiverVM Receiver { get; set; }

        public List<InvoiceLineVM> Lines { get; set; }
    }
}
