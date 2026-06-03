using Ahmed_Task_2.Web.DTO;
using Ahmed_Task_2.Web.Models;
using Ahmed_Task_2.Web.ViewModels;

namespace Ahmed_Task_2.Web.IService
{
    public interface IInvoiceService
    {
        Task<Result<bool>> CreateInvoiceAsync(InvoiceRequest request);
    }
}
