using Ahmed_Task_2.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Ahmed_Task_2.Web.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<ActivityCode> ActivityCodes { get; set; }
        public DbSet<InvoiceParty> InvoiceParties { get; set; }
        public DbSet<InvoiceLine> InvoiceLines { get; set; }
        public DbSet<InvoiceTax> InvoiceTaxes { get; set; }
        public DbSet<TaxType> TaxTypes { get; set; }
        public DbSet<TaxSubType> TaxSubTypes { get; set; }
    }
}
