using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Sales;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Sales
{
    public class Create
    {
        public class SaleData
        {
            public int CustomerId { get; set; }
            public int EmployeeId { get; set; }
            public int ProductId { get; set; }
            public int Quantity { get; set; }
        }

        public class Command : IRequest<SaleEnvelope>
        {
            public SaleData SaleData { get; set; }
        }

        public class Handler : IRequestHandler<Command, SaleEnvelope>
        {
            private readonly CleanContext _context;

            public Handler(CleanContext context)
            {
                _context = context;
            }

            public async Task<SaleEnvelope> Handle(Command request, CancellationToken cancellationToken)
            {
                var customer = await _context.Customers.SingleAsync(p => p.Id == request.SaleData.CustomerId, cancellationToken);
                var employee =
                    await _context.Employees.SingleAsync(p => p.Id == request.SaleData.EmployeeId, cancellationToken);
                var product = await _context.Products.SingleAsync(p => p.Id == request.SaleData.ProductId, cancellationToken);
                var quantity = request.SaleData.Quantity;

                var sale = new Sale
                {
                    Date = DateTime.Now,
                    Customer = customer,
                    Employee = employee,
                    Product = product,
                    Quantity = quantity,
                    UnitPrice = product.UnitPrice
                };

                await _context.AddAsync(sale, cancellationToken);

                await _context.SaveChangesAsync(cancellationToken);
                
                return new SaleEnvelope(sale);
            }
            
            
        }
    }
}