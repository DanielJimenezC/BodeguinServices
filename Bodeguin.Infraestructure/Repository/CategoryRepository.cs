using Bodeguin.Domain.Entity;
using Bodeguin.Domain.Interface;
using Bodeguin.Infraestructure.Context;

namespace Bodeguin.Infraestructure.Repository
{
    public class CategoryRepository : GenericRepository<Category, int>, ICategoryRepository
    {
        public CategoryRepository(PostgreSqlContext context) : base(context) { }
    }
}
