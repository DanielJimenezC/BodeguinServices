using Bodeguin.Domain.Entity;

namespace Bodeguin.Domain.Interface
{
    public interface IPaymentRepository : IRepository<PaymentType, int>
    {
    }
}
