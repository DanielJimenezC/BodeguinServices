using Bodeguin.Domain.Entity;
using Bodeguin.Domain.Interface;
using Bodeguin.Infraestructure.Context;

namespace Bodeguin.Infraestructure.Repository
{
    public class ProductRepository : GenericRepository<Product, int>, IProductRepository
    {
        public ProductRepository(PostgreSqlContext context) : base(context) { }
    }
}
