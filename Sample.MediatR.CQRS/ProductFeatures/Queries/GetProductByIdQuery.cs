using MediatR;
using Microsoft.EntityFrameworkCore;
using Sample.MediatR.CQRS.Context;
using Sample.MediatR.CQRS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.MediatR.CQRS.ProductFeatures.Queries
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public int Id { get; set; }
        public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
        {
            private readonly IApplicationContext _context;
            public GetProductByIdQueryHandler(IApplicationContext context)
            {
                _context = context;
            }

            public async Task<Product> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
            {
                var product = await _context.Products.Where(p => p.Id == query.Id).FirstOrDefaultAsync();
                return product;
            }
        }
    }
}
