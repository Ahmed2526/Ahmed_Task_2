using Ahmed_Task_2.Web.Data;
using Ahmed_Task_2.Web.IService;
using Ahmed_Task_2.Web.Models;
using Ahmed_Task_2.Web.ViewModels;

namespace Ahmed_Task_2.Web.Serivce
{
    public class InvoiceService : IInvoiceService
    {
        private readonly ApplicationDbContext _context;

        public InvoiceService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<Result<bool>> CreateInvoiceAsync(InvoiceVM invoice)
        {

            throw new NotImplementedException();
        }
    }
}
