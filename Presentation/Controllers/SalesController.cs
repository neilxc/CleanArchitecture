using System.Threading.Tasks;
using Application.Sales;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SalesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetSales()
        {
            var sales = await _mediator.Send(new List.Query());

            return Ok(sales);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSale(int id)
        {
            var sale = await _mediator.Send(new Details.Query
            {
                Id = id
            });

            return Ok(sale);
        }

        [HttpGet("saleFormValues")]
        public async Task<IActionResult> GetSalesFormValues()
        {
            var selectItems = await _mediator.Send(new GetSaleViewModel.Query());

            return Ok(selectItems);
        }

        [HttpPost]
        public async Task<SaleEnvelope> Create([FromBody]Create.Command command)
        {
            return await _mediator.Send(command);
        }
    }
}