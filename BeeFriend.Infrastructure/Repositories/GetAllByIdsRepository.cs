using BeeFriend.Core.Domain.RepositoryContracts.CrudRepositoryContracts.Getters;
using BeeFriend.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;

namespace BeeFriend.Infrastructure.Repositories
{
    public class GetAllByIdsRepository<TEntity, TKey> :
        IGetAllByIdsRepository<TEntity, TKey>

        where TEntity : class
        where TKey : struct
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public GetAllByIdsRepository(ApplicationDbContext context) 
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<IReadOnlyList<TEntity>> GetAllByIdsAsync(IEnumerable<TKey> keys, string idPropertyName)
        {
            return await _dbSet
                .Where(entity => keys.Contains(EF.Property<TKey>(entity, idPropertyName)))
                .ToListAsync();
        }
    }
}
