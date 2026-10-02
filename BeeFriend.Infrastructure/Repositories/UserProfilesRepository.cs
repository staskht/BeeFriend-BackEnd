using BeeFriend.Core.Domain.Entities;
using BeeFriend.Core.Domain.RepositoryContracts;
using BeeFriend.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;


namespace BeeFriend.Infrastructure.Repositories
{
    public class UserProfilesRepository : IUserProfilesRepository
    {
        private readonly ApplicationDbContext _context;

        public UserProfilesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(
            UserProfile userProfile, 
            CancellationToken cancellationToken)
        {
            await _context.UserProfiles.AddAsync(userProfile, cancellationToken);
        }

        public async Task<IReadOnlyList<UserProfile>> GetAllAsync(CancellationToken cancellationToken)
        {
            var userProfiles = await _context.UserProfiles
                .Include(u => u.City)
                .Include(u => u.Country)
                .Include(u => u.Interests)
                .Include(u => u.PersonalityTraits)
                .Include(u => u.FriendshipPreferences)
                .ToListAsync(cancellationToken);

            return userProfiles;
        }

        public async Task<UserProfile?> GetByIdAsync(
            Guid id, 
            CancellationToken cancellationToken)
        {
            var userProfile = await _context.UserProfiles
                .Include(u => u.City)
                .Include(u => u.Country)
                .Include(u => u.Interests)
                .Include(u => u.PersonalityTraits)
                .Include(u => u.FriendshipPreferences)
                .FirstOrDefaultAsync(u => u.Id == id, cancellationToken);

            return userProfile;
        }

        public void Update(UserProfile entity)
        {
            _context.UserProfiles.Update(entity);
        }
    }
}
