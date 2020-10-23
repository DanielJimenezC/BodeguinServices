using Bodeguin.Domain.Entity;
using Bodeguin.Domain.Interface;
using Bodeguin.Infraestructure.Context;

namespace Bodeguin.Infraestructure.Repository
{
    public class VoucherRepository : GenericRepository<Voucher, int>, IVoucherRepository
    {
        public VoucherRepository(PostgreSqlContext context) : base(context) { }
    }
}
