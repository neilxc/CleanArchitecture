using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Employees
{
    public class List
    {
        public class Query : IRequest<List<EmployeeModel>>{}

        public class QueryHandler : IRequestHandler<Query, List<EmployeeModel>>
        {
            private readonly CleanContext _context;

            public QueryHandler(CleanContext context)
            {
                _context = context;
            }
            public async Task<List<EmployeeModel>> Handle(Query request, CancellationToken cancellationToken)
            {
                var employees = _context.Employees.AsNoTracking().Select(p => new EmployeeModel
                {
                    Id = p.Id,
                    Name = p.Name
                });

                return await employees.ToListAsync(cancellationToken);
            }
        }
    }
}