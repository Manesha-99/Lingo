using Lingo.Model.Domain;

namespace Lingo.Repositories
{
    public interface ICountryRepository
    {
        Task<List<Country>> GetAllAsync(string? filterOn, string? filterQuery, string? sortBy, bool isAscending=true, int pageNumber=1, int pageSize=5);

        Task<Country> GetByIdAsync(Guid id);

        Task<Country> CreateAsync(Country country);

        Task<Country> UpdateAsync(Guid id,Country country);

        Task<Country> DeleteAsync(Guid id);
    }
}
