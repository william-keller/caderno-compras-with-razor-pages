using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using RIEG.Compras.Caderno.Pages.Models;

namespace RIEG.Compras.Caderno.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<RIEG.Compras.Caderno.Pages.Models.Product> Product { get; set; }
        public DbSet<RIEG.Compras.Caderno.Pages.Models.Category> Category { get; set; }
        public DbSet<RIEG.Compras.Caderno.Pages.Models.Priority> Priority { get; set; }
    }
}
