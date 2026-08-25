using BeeFriend.Core.Domain.Entities;
using BeeFriend.Core.Domain.RepositoryContracts;
using BeeFriend.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;

namespace BeeFriend.Infrastructure.Repositories
{
    public class PersonalityTraitsRepository :
        IPersonalityTraitsRepository
    {
        private readonly ApplicationDbContext _context;

        public PersonalityTraitsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Personality>> GetAllAsync()
        {
            var personalityTraits = await _context.PersonalityTraits.ToListAsync();

            return personalityTraits;
        }

        public async Task<IReadOnlyList<Personality>> GetAllByIdAsync(IEnumerable<int> keys)
        {
            var personalityTraits = await _context.PersonalityTraits
                .Where(i => keys.Contains(i.PerosnalityId))
                .ToListAsync();

            return personalityTraits;
        }
    }
}
