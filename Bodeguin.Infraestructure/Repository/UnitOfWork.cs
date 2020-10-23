using Bodeguin.Domain.Interface;
using Bodeguin.Infraestructure.Context;
using System.Threading.Tasks;

namespace Bodeguin.Infraestructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PostgreSqlContext _context;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IDetailRepository _detailRepository;
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IProductRepository _productRepository;
        private readonly IStoreRepository _storeRepository;
        private readonly IUserRepository _userRepository;
        private readonly IVoucherRepository _voucherRepository;

        public UnitOfWork(PostgreSqlContext context)
        {
            _context = context;
        }

        public ICategoryRepository CategoryRepository => _categoryRepository ?? new CategoryRepository(_context);
        public IDetailRepository DetailRepository => _detailRepository ?? new DetailRepository(_context);
        public IInventoryRepository InventoryRepository => _inventoryRepository ?? new InventoryRepository(_context);
        public IPaymentRepository PaymentRepository => _paymentRepository ?? new PaymentRepository(_context);
        public IProductRepository ProductRepository => _productRepository ?? new ProductRepository(_context);
        public IStoreRepository StoreRepository => _storeRepository ?? new StoreRepository(_context);
        public IUserRepository UserRepository => _userRepository ?? new UserRepository(_context);
        public IVoucherRepository VoucherRepository => _voucherRepository ?? new VoucherRepository(_context);

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }
    }
}
