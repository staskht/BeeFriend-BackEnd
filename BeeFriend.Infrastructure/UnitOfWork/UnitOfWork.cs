using BeeFriend.Core.Domain.RepositoryContracts;
using BeeFriend.Core.Domain.UnitOfWorkContract;
using BeeFriend.Infrastructure.DbContext;

namespace BeeFriend.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IUserProfilesRepository UserProfiles {  get; }
        public ICountriesRepository Countries { get; }
        public ICitiesRepository Cities { get; }

        public UnitOfWork(
            ApplicationDbContext context, 
            IUserProfilesRepository userProfiles,
            ICountriesRepository countries,
            ICitiesRepository cities
            )
        {
            _context = context;
            UserProfiles = userProfiles;
            Countries = countries;
            Cities = cities;
             
        }
        public Task CommitAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
