using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sample.MediatR.CQRS.ProductFeatures.Commands;
using Sample.MediatR.CQRS.ProductFeatures.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Sample.MediatR.CQRS.Controllers
{
    /// <summary>
    /// Controlador de Productos.
    /// Diferentes acciones para la entidad.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private IMediator _mediator;

        /// <summary>
        /// Mediador que simplifica el uso de las operaciones CRUD para la entidad.
        /// </summary>
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();


        /// <summary>
        /// Crea un producto a través de un comando.
        /// Retornando en Id generado.
        /// </summary>
        /// <param name="command"></param>
        /// <returns>Id</returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Borra un producto a través de un comando.
        /// Retornando el Id borrado.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Id</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteProductByIdCommand { Id = id }));
        }

        /// <summary>
        /// Obtiene todos los productos.
        /// </summary>
        /// <returns>Lista de productos readonly</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllProductsQuery()));
        }

        /// <summary>
        /// Obtiene un productos desde su Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Producto</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetProductByIdQuery { Id = id }));
        }

        /// <summary>
        /// Actualiza el producto a través de un comando.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateProductCommand command)
        {
            if (id != command.Id)
                return BadRequest();

            return Ok(await Mediator.Send(command));
        }
    }
}
