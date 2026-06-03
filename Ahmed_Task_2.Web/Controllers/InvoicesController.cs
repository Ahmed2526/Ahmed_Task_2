using Ahmed_Task_2.Web.Data;
using Ahmed_Task_2.Web.ViewModels;
using Ahmed_Task_2.Web.ViewModels.FormVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ahmed_Task_2.Web.Controllers
{
    public class InvoicesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InvoicesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var invoiceVM = await _context.Invoices
                .Where(i => i.InternalId == id)
                .Select(i => new InvoiceVM
                {
                    InternalId = i.InternalId,
                    ActivityCode = i.ActivityCode.Id,
                    DateIssued = i.DateIssued,
                    NetAmount = i.NetAmount,
                    TotalAmount = i.TotalAmount,
                    Issuer = new IssuerVM
                    {
                        Type = i.Issuer.Type.ToString(),
                        RegistrationId = i.Issuer.RegistrationId,
                        Name = i.Issuer.Name,
                        Country = i.Issuer.Country,
                        Governorate = i.Issuer.Governorate,
                        RegionCity = i.Issuer.RegionCity,
                        Street = i.Issuer.Street,
                        BuildingNumber = i.Issuer.BuildingNumber,
                        BranchId = i.Issuer.BranchId ?? "",
                    },
                    Receiver = new ReceiverVM
                    {
                        Type = i.Receiver.Type.ToString(),
                        RegistrationId = i.Receiver.RegistrationId,
                        Name = i.Receiver.Name,
                        Country = i.Receiver.Country,
                        Governorate = i.Receiver.Governorate,
                        RegionCity = i.Receiver.RegionCity,
                        Street = i.Receiver.Street,
                        BuildingNumber = i.Receiver.BuildingNumber
                    },
                    Lines = i.Lines.Select(l => new InvoiceLineVM
                    {
                        ItemCode = l.ItemCode,
                        Description = l.Description,
                        Quantity = l.Quantity,
                        UnitType = l.UnitType.ToString(),
                        UnitPrice = l.UnitPrice,
                        SalesTotal = l.SalesTotal,
                        DiscountPercentage = l.DiscountPercentage,
                        DiscountPerUnit = l.DiscountPerUnit,

                        Taxes = l.Taxes.Select(t => new InvoiceTaxVM
                        {
                            TaxType = t.TaxType.Name,
                            TaxSubType = t.TaxSubType.Name,
                            Amount = t.Amount,
                            Rate = t.Rate,
                        }).ToList()
                    }).ToList()
                })
                .AsNoTracking()
                .FirstOrDefaultAsync();


            return View(invoiceVM);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(InvoiceFormVM model)
        {
            var invoice = model;

            return View();
        }
    }
}
