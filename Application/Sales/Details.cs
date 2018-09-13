using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Sales
{
    public class Details
    {
        public class Query : IRequest<SaleDetailModel>
        {
            public int Id { get; set; }
        }

        public class QueryHandler : IRequestHandler<Query, SaleDetailModel>
        {
            private readonly CleanContext _context;

            public QueryHandler(CleanContext context)
            {
                _context = context;
            }
            public async Task<SaleDetailModel> Handle(Query request, CancellationToken cancellationToken)
            {
                var sale = _context.Sales
                    .Where(p => p.Id == request.Id)
                    .Select(p => new SaleDetailModel
                    {
                        Id = p.Id,
                        Date = p.Date,
                        CustomerName = p.Customer.Name,
                        EmployeeName = p.Employee.Name,
                        ProductName = p.Product.Name,
                        UnitPrice = p.UnitPrice,
                        Quantity = p.Quantity,
                        TotalPrice = p.TotalPrice
                    });

                return await sale.SingleAsync(cancellationToken);
            }
        }
    }
}