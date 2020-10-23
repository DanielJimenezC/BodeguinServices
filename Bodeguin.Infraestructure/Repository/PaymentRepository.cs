using Bodeguin.Domain.Entity;
using Bodeguin.Domain.Interface;
using Bodeguin.Infraestructure.Context;

namespace Bodeguin.Infraestructure.Repository
{
    public class PaymentRepository : GenericRepository<PaymentType, int>, IPaymentRepository
    {
        public PaymentRepository(PostgreSqlContext context) : base(context) { }
    }
}
