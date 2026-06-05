using System;
using Ahmed_Task_2.Web.Data;
using Ahmed_Task_2.Web.Enums;
using Ahmed_Task_2.Web.IService;
using Ahmed_Task_2.Web.ViewModels.FormVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
    }
}