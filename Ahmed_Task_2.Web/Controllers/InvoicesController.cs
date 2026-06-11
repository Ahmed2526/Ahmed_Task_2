using Ahmed_Task_2.Web.Data;
using Ahmed_Task_2.Web.DTO;
using Ahmed_Task_2.Web.Enums;
using Ahmed_Task_2.Web.IService;
using Ahmed_Task_2.Web.Models;
using Ahmed_Task_2.Web.ViewModels;
using Ahmed_Task_2.Web.ViewModels.FormVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace Ahmed_Task_2.Web.Controllers
{
    public class InvoicesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IInvoiceService _invoiceService;

        public InvoicesController(ApplicationDbContext context, IInvoiceService invoiceService)
        {
            _context = context;
            _invoiceService = invoiceService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var invoiceVM = await _invoiceService.GetByIdAsync(id);

            if (!invoiceVM.IsSuccess)
                return NotFound();

            return View(invoiceVM.Data);
        }


        [HttpGet]
        public IActionResult Create()
        {
            var model = new InvoiceFormVM();
            model = PopulateSelectLists(model);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(InvoiceFormVM model)
        {
            if (!ModelState.IsValid)
            {
                model = PopulateSelectLists(model);

                return View(model);
            }

            var result = await _invoiceService.CreateInvoiceMVCAsync(model);

            if (!result.IsSuccess)
            {
                foreach (var error in result.Errors!)
                    ModelState.AddModelError("", error);

                model = PopulateSelectLists(model);
                return View(model);
            }

            return RedirectToAction("Details", new { id = result.Data });
        }

        private InvoiceFormVM PopulateSelectLists(InvoiceFormVM model)
        {
            model.DateIssued = DateOnly.FromDateTime(DateTime.Now);

            model.ActivityCodeList = _context.ActivityCodes.Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.Name
            }).ToList();
            model.Issuer.PartyTypesList = Enum.GetValues<PartyType>().Select(p => new SelectListItem
            {
                Value = ((int)p).ToString(),
                Text = p.ToString()
            }).ToList();
            model.Receiver.PartyTypesList = Enum.GetValues<PartyType>().Select(p => new SelectListItem
            {
                Value = ((int)p).ToString(),
                Text = p.ToString()
            }).ToList();

            return model;
        }

        public JsonResult IsInternalIdUnique(string internalId)
        {
            var isUnique = !_context.Invoices.Any(i => i.InternalId == internalId);
            return Json(isUnique);
        }

        [HttpPost]
        public IActionResult CalculateTaxes([FromBody] List<TaxAjaxRequest> taxes)
        {
            if (taxes is null || !taxes.Any())
                return Ok();

            decimal TotalTaxes = 0;
            decimal NetTotal = taxes[0].NetTotal;

            decimal TaxFromT5ToT12 = 0;
            decimal TaxT2 = 0;
            decimal TaxT3 = 0;

            foreach (var tax in taxes)
            {
                if (tax.TaxType == 3)
                    TaxT3 += tax.Amount;

                if (tax.TaxType == 5 || tax.TaxType == 6 || tax.TaxType == 7 || tax.TaxType == 8 || tax.TaxType == 9 || tax.TaxType == 10 || tax.TaxType == 11 || tax.TaxType == 12)
                {
                    TaxFromT5ToT12 += tax.Amount;
                }
            }

            taxes = taxes.OrderByDescending(x => x.TaxType).ToList();

            foreach (var tax in taxes)
            {
                decimal NetSale = 0;
                decimal T2 = 0;

                // T1 - Value added tax
                if (tax.TaxType == 1)
                {
                    NetSale = NetTotal;
                    var T1 = (NetSale + TaxFromT5ToT12 + TaxT2 + TaxT3) * tax.Rate / 100;

                    TotalTaxes += T1;
                }

                // T2 - Table tax
               else if (tax.TaxType == 2)
                {
                    NetSale = NetTotal;
                    T2 = (NetSale + TaxFromT5ToT12) * tax.Rate / 100;

                    TaxT2 = T2;

                    TotalTaxes += T2;
                }

                else
                {
                    TotalTaxes += tax.Amount;
                }

            }

            return Ok(TotalTaxes);
        }

    }
}