using MediatR;
using Microsoft.EntityFrameworkCore;
using Sample.MediatR.CQRS.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.MediatR.CQRS.ProductFeatures.Commands
{
    public class DeleteProductByIdCommand: IRequest<int>
    {
        public int Id { get; set; }

        public class DeleteProductByIdCommandHandler : IRequestHandler<DeleteProductByIdCommand, int>
        {
            private readonly IApplicationContext _context;

            public DeleteProductByIdCommandHandler(IApplicationContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(DeleteProductByIdCommand command, CancellationToken cancellationToken)
            {
                var product = await _context.Products.Where(p => p.Id == command.Id).FirstOrDefaultAsync();
                if (product == null)
                    return default;

                _context.Products.Remove(product);
                await _context.SaveChanges();
                return product.Id;
            }
        }
    }
}
