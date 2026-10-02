using BeeFriend.Core.Domain.Entities;
using BeeFriend.Core.Domain.RepositoryContracts;
using BeeFriend.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;


namespace BeeFriend.Infrastructure.Repositories
{
    public class CountriesRepository : ICountriesRepository
    {
        private readonly ApplicationDbContext _context;

        public CountriesRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IReadOnlyList<Country>> GetAllAsync(CancellationToken cancellationToken)
        {
            var countries = await _context.Countries
                .OrderBy(c => c.Name)
                .ToListAsync(cancellationToken);

            return countries;
        }

        public async Task<Country?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            var country = 
                await _context.Countries.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

            return country;
        }
    }
}
