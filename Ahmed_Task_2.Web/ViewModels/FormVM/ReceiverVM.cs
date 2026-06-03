using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ahmed_Task_2.Web.ViewModels.FormVM
{
    public class ReceiverVM
    {
        public string Type { get; set; }
        public string RegistrationId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Governorate { get; set; }
        public string RegionCity { get; set; }
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
    }
}
