using MediatR;
using Sample.MediatR.CQRS.Context;
using Sample.MediatR.CQRS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.MediatR.CQRS.ProductFeatures.Commands
{
    /// <summary>
    /// Estructura del objeto que va a realizar el nuevo Producto.
    /// </summary>
    public class CreateProductCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public decimal BuyingPrice { get; set; }
        public decimal Rate { get; set; }

        public class CreateProductCommandhandler : IRequestHandler<CreateProductCommand, int>
        {
            private readonly IApplicationContext _context;
            public CreateProductCommandhandler(IApplicationContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(CreateProductCommand command, CancellationToken cancellationToken)
            {
                var product = new Product();
                product.Barcode = command.Barcode;
                product.Name = command.Name;
                product.Description = command.Description;
                product.BuyingPrice = command.BuyingPrice;
                product.Rate = command.Rate;

                _context.Products.Add(product);
                await _context.SaveChanges();
                return product.Id;
            }
        }
    }
}
