using BeeFriend.Core.Domain.Entities;
using BeeFriend.Core.Domain.RepositoryContracts;
using BeeFriend.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;

namespace BeeFriend.Infrastructure.Repositories
{
    public class InterestsRepository :
        IInterestsRepository
    {
        private readonly ApplicationDbContext _context;
        public InterestsRepository(ApplicationDbContext context) 
        {
            _context = context;
        }
        public async Task<IReadOnlyList<Interest>> GetAllByIdAsync(IEnumerable<int> ids)
        {
            var interests = await _context.Interests
                .Where(i => ids.Contains(i.InterestId))
                .ToListAsync();

            return interests;
        }
    }
}
