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
        }

        public void Delete(UserProfile userProfile)
        {
            _context.UserProfiles.Remove(userProfile);
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

        public UserProfile Update(UserProfile entity)
        {
            _context.UserProfiles.Update(entity);
            return entity;
        }
    }
}
