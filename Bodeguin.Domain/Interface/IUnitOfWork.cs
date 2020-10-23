using System;
using System.Threading.Tasks;

namespace Bodeguin.Domain.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository CategoryRepository { get; }
        IDetailRepository DetailRepository { get; }
        IInventoryRepository InventoryRepository { get; }
        IPaymentRepository PaymentRepository { get; }
        IProductRepository ProductRepository { get; }
        IStoreRepository StoreRepository { get; }
        IUserRepository UserRepository { get; }
        IVoucherRepository VoucherRepository { get; }
        Task<int> SaveChangesAsync();
    }
}
