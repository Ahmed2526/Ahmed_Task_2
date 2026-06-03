using Ahmed_Task_2.Web.DTO;
using Ahmed_Task_2.Web.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ahmed_Task_2.Web.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        public InvoicesController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }


        [HttpPost]
        public async Task<IActionResult> Create(InvoiceRequest invoiceRequest)
        {
            var result = await _invoiceService.CreateInvoiceAsync(invoiceRequest);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
