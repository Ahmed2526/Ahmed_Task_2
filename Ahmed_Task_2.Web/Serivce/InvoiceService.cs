using Ahmed_Task_2.Web.Data;
using Ahmed_Task_2.Web.DTO;
using Ahmed_Task_2.Web.@enum;
using Ahmed_Task_2.Web.IService;
using Ahmed_Task_2.Web.Models;
using Ahmed_Task_2.Web.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Ahmed_Task_2.Web.Serivce
{
    public class InvoiceService : IInvoiceService
    {
        private readonly ApplicationDbContext _context;

        public InvoiceService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result<bool>> CreateInvoiceAsync(InvoiceRequest request)
        {
            var invoiceExist = await _context.Invoices.AnyAsync(i => i.InternalId == request.InternalId);

            if (invoiceExist)
                return Result<bool>.Fail(400, new string[] { "Invoice with the same InternalId already exists." });

            if (request.DateIssued > DateOnly.FromDateTime(DateTime.UtcNow))
                return Result<bool>.Fail(400, new[] { "DateIssued cannot be in the future." });

            if (!await _context.ActivityCodes.AnyAsync(ac => ac.Id == request.ActivityCode))
                return Result<bool>.Fail(400, new[] { "Invalid ActivityCode." });

            if (request.Issuer.RegistrationId == request.Receiver.RegistrationId)
                return Result<bool>.Fail(400, new[] { "Issuer and receiver RegistrationId must be different." });


            var invoice = new Invoice
            {
                InternalId = request.InternalId,
                DateIssued = request.DateIssued,
                ActivityCodeId = request.ActivityCode,
            };

            invoice.Issuer = new InvoiceParty
            {
                Type = (PartyType)request.Issuer.TypeId,
                RegistrationId = request.Issuer.RegistrationId,
                Name = request.Issuer.Name,
                Country = request.Issuer.Country,
                Governorate = request.Issuer.Governorate,
                RegionCity = request.Issuer.RegionCity,
                Street = request.Issuer.Street,
                BuildingNumber = request.Issuer.BuildingNumber,
                BranchId = request.Issuer.BranchId,
            };

            invoice.Receiver = new InvoiceParty
            {
                Type = (PartyType)request.Receiver.TypeId,
                RegistrationId = request.Receiver.RegistrationId,
                Name = request.Receiver.Name,
                Country = request.Receiver.Country,
                Governorate = request.Receiver.Governorate,
                RegionCity = request.Receiver.RegionCity,
                Street = request.Receiver.Street,
                BuildingNumber = request.Receiver.BuildingNumber,
                BranchId = null
            };

            foreach (var line in request.Lines)
            {
                var invoiceLine = new InvoiceLine
                {
                    ItemCode = line.ItemCode,
                    Description = line.Description,
                    Quantity = line.Quantity,
                    UnitType = (UnitType)line.UnitTypeId,
                    UnitPrice = line.UnitPrice,
                    SalesTotal = line.UnitPrice * line.Quantity,
                    DiscountPerUnit = line.DiscountPerUnit,
                    DiscountPercentage = line.DiscountPercentage,
                    NetTotal = CalculateNetTotal(line),
                };

                foreach (var tax in line?.Taxes ?? Enumerable.Empty<InvoiceTaxRequest>())
                {
                    if (!await _context.TaxTypes.AnyAsync(x => x.Id == tax.TaxType))
                        return Result<bool>.Fail(400, new[] { "Invalid TaxType." });

                    if (!await _context.TaxSubTypes.AnyAsync(x => x.Id == tax.TaxSubType))
                        return Result<bool>.Fail(400, new[] { "Invalid TaxSubType." });

                    var invoiceTax = new InvoiceTax
                    {
                        TaxTypeId = tax.TaxType,
                        TaxSubTypeId = tax.TaxSubType,
                        Amount = tax.Amount,
                        Rate = tax.Rate,
                    };

                    invoiceLine.TotalTaxableFees += tax.Amount;

                    invoiceLine.Taxes.Add(invoiceTax);
                }

                invoiceLine.Total = invoiceLine.NetTotal + invoiceLine.TotalTaxableFees;

                invoice.Lines.Add(invoiceLine);
            }

            invoice.NetAmount = invoice.Lines.Sum(l => l.NetTotal);
            invoice.TotalAmount = invoice.Lines.Sum(l => l.Total);

            await _context.Invoices.AddAsync(invoice);
            await _context.SaveChangesAsync();

            return Result<bool>.Success(StatusCodes.Status200OK, true);
        }

        private decimal CalculateNetTotal(InvoiceLineRequest LineRequest)
        {
            //1000          2.5                *        400    
            var lineTotal = LineRequest.UnitPrice * LineRequest.Quantity;
            //          2020                .3                *        400           +(  1000     *               2             /100 )
            var discountAmount = LineRequest.DiscountPerUnit * LineRequest.Quantity + (lineTotal * LineRequest.DiscountPercentage / 100);
            //    1000       - 140
            return lineTotal - discountAmount;
        }


    }
}
