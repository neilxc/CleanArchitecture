using Domain.Sales;

namespace Application.Sales
{
    public class SaleEnvelope
    {
        public SaleEnvelope(Sale sale)
        {
            Sale = sale;
        }

        private Sale Sale { get; }
    }
}