using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using BudgetCalculator.Models;

namespace BudgetCalculator.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<BudgetCalculator.Models.Budget> Budget { get; set; }
        public DbSet<BudgetCalculator.Models.BudgetItems> BudgetItems { get; set; }
    }
}
