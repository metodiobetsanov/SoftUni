using FDMC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FDMC.Data
{
    public class FDMCDbContext : IdentityDbContext<FdmcUser>
    {
        public FDMCDbContext(DbContextOptions<FDMCDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}