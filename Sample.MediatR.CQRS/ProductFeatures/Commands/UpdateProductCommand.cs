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
    /// <summary>
    /// Estructura del objeto que va a modificar el Producto.
    /// </summary>
    public class UpdateProductCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public decimal BuyingPrice { get; set; }
        public decimal Rate { get; set; }

        public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, int>
        {
            private readonly IApplicationContext _context;

            public UpdateProductCommandHandler(IApplicationContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
            {
                var product = _context.Products.Where(p => p.Id == command.Id).FirstOrDefault();
                if (product == null)
                    return default;
                else
                {
                    product.Name = command.Name;
                    product.Barcode = command.Barcode;
                    product.Description = command.Description;
                    product.BuyingPrice = command.BuyingPrice;
                    product.Rate = command.Rate;

                    await _context.SaveChanges();
                    return product.Id;
                }
            }
        }
    }
}
