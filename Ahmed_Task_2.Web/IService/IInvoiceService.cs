using Ahmed_Task_2.Web.DTO;
using Ahmed_Task_2.Web.Models;
using Ahmed_Task_2.Web.ViewModels;
using Ahmed_Task_2.Web.ViewModels.FormVM;

namespace Ahmed_Task_2.Web.IService
{
    public interface IInvoiceService
    {
        Task<Result<bool>> CreateInvoiceAsync(InvoiceRequest request);
        Task<Result<string>> CreateInvoiceMVCAsync(InvoiceFormVM FormVM);
        Task<Result<InvoiceVM>> GetByIdAsync(string InternalId);


    }
}
