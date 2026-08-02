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

        public async Task<IEnumerable<UserProfile>> GetAllAsync()
        {
            var userProfiles = await _context.UserProfiles
                .Include(u => u.City)
                .ToListAsync();

            return userProfiles;
        }

        public async Task<UserProfile?> GetByIdAsync(Guid id)
        {
            var userProfile = await _context.UserProfiles
                .Include(u => u.City)
                .FirstOrDefaultAsync(u => u.UserId == id);

            return userProfile;
        }

        public async Task<UserProfile?> UpdateAsync(UserProfile entity)
        {
            UserProfile? matchingUserProfile = await _context.UserProfiles.FindAsync(entity.UserId);

            matchingUserProfile.CityId = entity.CityId;
            matchingUserProfile.FirstName = entity.FirstName;
            matchingUserProfile.Bio = entity.Bio;
            matchingUserProfile.Gender = entity.Gender;
            matchingUserProfile.Pronouns = entity.Pronouns;
            matchingUserProfile.Interests = entity.Interests;

            await _context.SaveChangesAsync();
            return matchingUserProfile;
        }
    }
}
