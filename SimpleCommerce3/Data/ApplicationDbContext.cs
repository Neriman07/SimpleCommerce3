using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SimpleCommerce3.Models;

namespace SimpleCommerce3.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<SimpleCommerce3.Models.Product> Products{ get; set; }
        public DbSet<SimpleCommerce3.Models.Category> Categories { get; set; }
        public DbSet<SimpleCommerce3.Models.Slide> Slides { get; set; }
        public DbSet<SimpleCommerce3.Models.Cart> Carts { get; set; }
        public DbSet<SimpleCommerce3.Models.CartItem> cartItems { get; set; }
        public DbSet<SimpleCommerce3.Models.Order> Orders { get; set; }
        public DbSet<SimpleCommerce3.Models.Customer> Customers { get; set; }
        public DbSet<SimpleCommerce3.Models.Region> Regions { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
