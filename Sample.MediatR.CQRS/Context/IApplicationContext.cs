using Microsoft.EntityFrameworkCore;
using Sample.MediatR.CQRS.Models;
using System.Threading.Tasks;

namespace Sample.MediatR.CQRS.Context
{
    public interface IApplicationContext
    {
        DbSet<Product> Products { get; set; }

        Task<int> SaveChanges();
    }
}