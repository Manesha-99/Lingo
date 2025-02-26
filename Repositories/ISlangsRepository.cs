using Lingo.Model.Domain;

namespace Lingo.Repositories
{
    public interface ISlangsRepository
    {
        Task<List<Slang>> GetAllAsync(string? filterOn=null, string? filterQuery = null, string? sortBy = null, bool isAscending=true,
            int pageNumber=1, int pageSize=100);

        Task<Slang> GeyByIdAsync(Guid id);

        Task<Slang> CreateAsync(Slang slang);

        Task<Slang> UpdateAsync(Guid id, Slang slang);

        Task<Slang> DeleteAsync(Guid id);
    }
}
