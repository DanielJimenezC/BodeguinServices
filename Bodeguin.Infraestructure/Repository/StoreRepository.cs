using Bodeguin.Domain.Entity;
using Bodeguin.Domain.Interface;
using Bodeguin.Infraestructure.Context;

namespace Bodeguin.Infraestructure.Repository
{
    public class StoreRepository : GenericRepository<Store, int>, IStoreRepository
    {
        public StoreRepository(PostgreSqlContext context) : base(context) { }
    }
}
