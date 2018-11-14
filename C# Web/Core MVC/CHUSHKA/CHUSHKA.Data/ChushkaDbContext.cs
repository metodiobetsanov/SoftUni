using System;
using System.Collections.Generic;
using System.Text;
using CHUSHKA.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CHUSHKA.Data
{
    public class ChushkaDbContext : IdentityDbContext<ChushkaUser>
    {

        public ChushkaDbContext(DbContextOptions<ChushkaDbContext> options)
            : base(options)
        {

        }

       public DbSet<Product> Products { get; set; }

       public DbSet<Order> Orders { get; set; }
    }
}
