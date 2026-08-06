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

        public async Task CreateAsync(UserProfile userProfile)
        {
            await _context.UserProfiles.AddAsync(userProfile);
            await _context.SaveChangesAsync();
        }

        public Task<bool> DeleteByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<UserProfile>> GetAllAsync()
        {
            var userProfiles = await _context.UserProfiles
                .Include(u => u.City)
                .Include(u => u.Country)
                .ToListAsync();

            return userProfiles;
        }

        public async Task<UserProfile?> GetByIdAsync(Guid id)
        {
            var userProfile = await _context.UserProfiles
                .Include(u => u.City)
                .Include(u => u.Country)
                .FirstOrDefaultAsync(u => u.UserId == id);

            return userProfile;
        }

        public async Task<UserProfile> UpdateAsync(UserProfile entity)
        {
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
