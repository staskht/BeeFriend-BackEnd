using BeeFriend.Core.Domain.Entities;
using BeeFriend.Core.Domain.RepositoryContracts;
using BeeFriend.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;

namespace BeeFriend.Infrastructure.Repositories
{
    public class FriendshipPreferencesRepository :
        IFriendshipPreferencesRepository
    {
        private readonly ApplicationDbContext _context;

        public FriendshipPreferencesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<FriendshipPreference>> GetAllAsync()
        {
            var preferneces = await _context.FriendshipPreferences.ToListAsync();

            return preferneces;
        }

        public async Task<IReadOnlyList<FriendshipPreference>> GetAllByIdAsync(IEnumerable<int> keys)
        {
            var preferneces = await _context.FriendshipPreferences
                .Where(i => keys.Contains(i.PreferenceId))
                .ToListAsync();

            return preferneces;
        }
    }
}
