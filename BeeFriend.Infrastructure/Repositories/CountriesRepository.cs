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
        public async Task<IReadOnlyList<Country>> GetAllAsync()
        {
            var countries = await _context.Countries
                .OrderBy(c => c.Name)
                .ToListAsync();

            return countries;
        }
    }
}
