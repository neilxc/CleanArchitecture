using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Sales
{
    public class List
    {
        public class Query : IRequest<List<SaleListModel>>{}

        public class QueryHandler : IRequestHandler<Query, List<SaleListModel>>
        {
            private readonly CleanContext _context;

            public QueryHandler(CleanContext context)
            {
                _context = context;
            }
            public async Task<List<SaleListModel>> Handle(Query request, CancellationToken cancellationToken)
            {
                var sales = _context.Sales
                    .Select(p => new SaleListModel
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

                return await sales.ToListAsync(cancellationToken);
            }
        }
    }
}