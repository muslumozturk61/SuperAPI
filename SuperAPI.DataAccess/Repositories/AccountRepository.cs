using Microsoft.EntityFrameworkCore;
using SuperAPI.DataAccess.Entities;

namespace SuperAPI.DataAccess.Repositories;

public class AccountRepository : SuperBase.DataAccess.RepositoryBase<Account, Guid>
{
    public AccountRepository(DbContext dbContext) : base(dbContext)
    {
    }
}