using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Products
{
    public class List
    {
        public class Query : IRequest<List<ProductModel>>
        {
        }

        public class QueryHandler : IRequestHandler<Query, List<ProductModel>>
        {
            private readonly CleanContext _context;

            public QueryHandler(CleanContext context)
            {
                _context = context;
            }

            public async Task<List<ProductModel>> Handle(Query request, CancellationToken cancellationToken)
            {
                var products = _context.Products.AsNoTracking().Select(p => new ProductModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    UnitPrice = p.UnitPrice
                });

                return await products.ToListAsync(cancellationToken);
            }
        }
    }
}