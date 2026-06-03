using Ahmed_Task_2.Web.Data;
using Ahmed_Task_2.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(InvoiceVM model)
        {
            var invoice = model;


            return View();
        }
    }
}
