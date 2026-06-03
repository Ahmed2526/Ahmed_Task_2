using Ahmed_Task_2.Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ahmed_Task_2.Web.ViewModels.FormVM
{
    public class IssuerFormVM
    {
        public int TypeId { get; set; }
        public List<SelectListItem>? PartyTypesList { get; set; }

        public string RegistrationId { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public string Governorate { get; set; }

        public string RegionCity { get; set; }

        public string Street { get; set; }

        public string BuildingNumber { get; set; }

        public string BranchId { get; set; }
    }
}
