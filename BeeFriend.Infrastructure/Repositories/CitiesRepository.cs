using BeeFriend.Core.Domain.Entities;
using BeeFriend.Core.Domain.RepositoryContracts;
using BeeFriend.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;

namespace BeeFriend.Infrastructure.Repositories
{
    public class CitiesRepository : ICitiesRepository
    {
        private readonly ApplicationDbContext _context;

        public CitiesRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IReadOnlyList<City>> GetAllByIdAsync(int countryId)
        {
            var cities = await _context.Cities
                .Where(c =>  c.CountryId == countryId)
                .OrderBy(c => c.Name)
                .ToListAsync();

            return cities;
        }
    }
}
