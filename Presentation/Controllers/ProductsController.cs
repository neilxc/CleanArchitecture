using System.Threading.Tasks;
using Application.Products;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET
        public async Task<IActionResult> GetProducts()
        {
            var products = await _mediator.Send(new List.Query());

            return Ok(products);
        }
    }
}