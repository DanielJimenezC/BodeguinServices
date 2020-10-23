using Bodeguin.Domain.Entity;
using Bodeguin.Domain.Interface;
using Bodeguin.Infraestructure.Context;

namespace Bodeguin.Infraestructure.Repository
{
    public class UserRepository : GenericRepository<User, int>, IUserRepository
    {
        public UserRepository(PostgreSqlContext context) : base(context) { }
    }
}
