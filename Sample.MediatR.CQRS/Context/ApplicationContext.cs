using Microsoft.EntityFrameworkCore;
using Sample.MediatR.CQRS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.MediatR.CQRS.Context
{
    public class ApplicationContext : DbContext, IApplicationContext
    {
        public DbSet<Product> Products { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        { }

        public async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }
    }
}
