using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistence;

namespace Application.Sales
{
    public class GetSaleViewModel
    {
        public class Query : IRequest<CreateSaleViewModel>{}

        public class QueryHandler : IRequestHandler<Query, CreateSaleViewModel>
        {
            private readonly CleanContext _context;

            public QueryHandler(CleanContext context)
            {
                _context = context;
            }

            public async Task<CreateSaleViewModel> Handle(Query request, CancellationToken cancellationToken)
            {
                var employees = _context.Employees;
                var customers = _context.Customers;
                var products = _context.Products;

                var salesModel = new CreateSaleViewModel
                {
                    Employees = employees.Select(p => new SelectListItem {Value = p.Id, Text = p.Name}).ToList(),
                    Customers = customers.Select(p => new SelectListItem {Value = p.Id, Text = p.Name}).ToList(),
                    Products = products.Select(p => 
                        new SelectListItem {Value = p.Id, Text = p.Name + " ($" + p.UnitPrice + ")"}).ToList()
                };

//                return Task.Run(() => salesModel, cancellationToken);
                return await Task.FromResult(salesModel);
            }
        }
    }
}