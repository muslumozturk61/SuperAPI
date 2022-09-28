using Microsoft.EntityFrameworkCore;
using SuperAPI.DataAccess.Entities;

namespace SuperAPI.DataAccess.Repositories
{
    public class OwnerRepository:SuperBase.DataAccess.RepositoryBase<Owner,Guid>
    {
        public OwnerRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
