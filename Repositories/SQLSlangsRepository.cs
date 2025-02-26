using Lingo.Data;
using Lingo.Model.Domain;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Lingo.Repositories
{
    public class SQLSlangsRepository : ISlangsRepository
    {
        private readonly LingoDbContext dbContext;

        public SQLSlangsRepository(LingoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        //Create----------------------

        public async Task<Slang> CreateAsync(Slang slang)
        {
            await dbContext.AddAsync(slang);
            await dbContext.SaveChangesAsync();

            return slang;
        }

        //DeleteByID-------------------
        public async Task<Slang> DeleteAsync(Guid id)
        {
           var item = await dbContext.Slangs.FirstOrDefaultAsync(x=>x.Id == id);

            if (item != null) {

                dbContext.Slangs.Remove(item);
                await dbContext.SaveChangesAsync();

                return item;
            
            }

            return null;

        }

        //Get All-------------------
        public async Task<List<Slang>> GetAllAsync(string? filterOn = null, string? filterQuery = null, string? sortBy = null, bool isAscending=true,
            int pageNumber=1, int pageSize=100)
        {
            //Filtering

            var slangs = dbContext.Slangs.AsQueryable();

            if(string.IsNullOrWhiteSpace(filterOn)==false && string.IsNullOrWhiteSpace(filterQuery) == false)
            {
                if (filterOn.Equals("Word", StringComparison.OrdinalIgnoreCase))
                {
                    slangs = slangs.Where(x=>x.Word.Contains(filterQuery));
                }
            }

            //Sorting

            if (string.IsNullOrWhiteSpace(sortBy)==false)
            {
                if(sortBy.Equals("Word", StringComparison.OrdinalIgnoreCase))
                {
                    slangs = isAscending ? slangs.OrderBy(x=>x.Word) : slangs.OrderByDescending(x=>x.Word);
                }
            }

            //Pagination

            var skipResults = (pageNumber - 1) * pageSize;

            
            return await slangs.Skip(skipResults).Take(pageSize).ToListAsync();
        }


        //GetById--------------------
        public async Task<Slang> GeyByIdAsync(Guid id)
        {
            return await dbContext.Slangs.FirstOrDefaultAsync(x=>x.Id == id);

        }

        //UpdateById-------------------
        public async Task<Slang> UpdateAsync(Guid id, Slang slang)
        {
           var existModel = await dbContext.Slangs.FirstOrDefaultAsync(x=>x.Id==id);

            if (existModel != null) { 
                
                existModel.Word = slang.Word;
                existModel.Meaning = slang.Meaning;
                existModel.StrongLevelId = slang.StrongLevelId;
                existModel.CountryId = slang.CountryId;
                existModel.ContinentId = slang.ContinentId;

                await dbContext.SaveChangesAsync();
                
                return existModel;
            }

            return null;
        }


    }
}
