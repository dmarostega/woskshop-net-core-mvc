using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SalesWebApp.Models
{
    public class SalesWebAppContext : DbContext
    {
        public SalesWebAppContext (DbContextOptions<SalesWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<SalesWebApp.Models.Department> Department { get; set; }
    }
}
