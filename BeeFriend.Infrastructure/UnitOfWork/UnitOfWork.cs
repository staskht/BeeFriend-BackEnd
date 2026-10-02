using BeeFriend.Core.Domain.RepositoryContracts;
using BeeFriend.Core.Domain.UnitOfWorkContract;
using BeeFriend.Infrastructure.DbContext;

namespace BeeFriend.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task CommitAsync(CancellationToken cancellationToken)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }
    }
}
