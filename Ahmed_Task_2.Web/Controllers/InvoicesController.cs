using Ahmed_Task_2.Web.Data;
using Ahmed_Task_2.Web.IService;
using Ahmed_Task_2.Web.ViewModels.FormVM;
using Microsoft.AspNetCore.Mvc;

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
