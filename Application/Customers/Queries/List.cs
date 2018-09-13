using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Customers.Queries
{
    public class List
    {
        public class Query : IRequest<List<CustomerModel>>{}

        public class QueryHandler : IRequestHandler<Query, List<CustomerModel>>
        {
            private readonly CleanContext _context;

            public QueryHandler(CleanContext context)
            {
                _context = context;
            }
            
            public async Task<List<CustomerModel>> Handle(Query request, CancellationToken cancellationToken)
            {
                var customers = _context.Customers.AsNoTracking().Select(p => new CustomerModel
                {
                    Id = p.Id,
                    Name = p.Name
                });

                var customersToReturn = await customers.ToListAsync(cancellationToken);

                return customersToReturn;
            }
        }
    }
}