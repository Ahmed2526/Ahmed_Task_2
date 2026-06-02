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

    }
}
