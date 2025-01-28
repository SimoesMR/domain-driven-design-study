using Domain.Repositories;

namespace Infrastructure.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApiDbContext _dbContext;

        public UnitOfWork(ApiDbContext dbContext) => _dbContext = dbContext;

        public async Task Commit() => await _dbContext.SaveChangesAsync();
 
    }
}
