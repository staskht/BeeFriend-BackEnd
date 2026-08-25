using BeeFriend.Core.Domain.Entities;
using BeeFriend.Core.Domain.RepositoryContracts;
using BeeFriend.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;

namespace BeeFriend.Infrastructure.Repositories
{
    public class InterestCategoriesRepository :
        IInterestCategoriesRepository
    {
        private readonly ApplicationDbContext _context;

        public InterestCategoriesRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IReadOnlyList<InterestCategory>> GetAllAsync()
        {
            var categories = 
                await _context.InterestCategories
                .Include(ic => ic.Interests)
                .ToListAsync();

            return categories;
        }
    }
}
