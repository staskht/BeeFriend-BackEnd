using BeeFriend.Core.Domain.Entities;
using BeeFriend.Core.Domain.RepositoryContracts;
using BeeFriend.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;

namespace BeeFriend.Infrastructure.Repositories
{
    public class InterestCategoriesRepository : 
        Repository<InterestCategory, int>,
        IInterestCategoriesRepository
    {
        public InterestCategoriesRepository(ApplicationDbContext context) : 
            base(context)
        {
        }

        public async Task<IReadOnlyList<InterestCategory>> GetAllCategoriesWithInterestsAsync()
        {
            var interests =
                await _dbSet
                .Include(ic => ic.Interests)
                .ToListAsync();

            return interests;
        }
    }
}
