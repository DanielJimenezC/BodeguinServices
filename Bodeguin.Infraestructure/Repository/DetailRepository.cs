using Bodeguin.Domain.Entity;
using Bodeguin.Domain.Interface;
using Bodeguin.Infraestructure.Context;

namespace Bodeguin.Infraestructure.Repository
{
    public class DetailRepository : GenericRepository<Detail, int>, IDetailRepository
    {
        public DetailRepository(PostgreSqlContext context) : base(context) { }
    }
}
