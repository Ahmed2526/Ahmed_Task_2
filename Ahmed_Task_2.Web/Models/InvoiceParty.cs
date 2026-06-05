using Ahmed_Task_2.Web.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Eventing.Reader;

namespace Ahmed_Task_2.Web.Models
{
    public class InvoiceParty
    {
        public int Id { get; set; }
        public PartyType Type { get; set; }
        public string RegistrationId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Governorate { get; set; }
        public string RegionCity { get; set; }
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
        public string? BranchId { get; set; }
        public int InvoiceId { get; set; }
    }
}
