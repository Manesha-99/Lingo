using Lingo.Controllers;
using Lingo.Data;
using Lingo.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace Lingo.Repositories
{
    public class CountryRepository: ICountryRepository
    {
        private readonly LingoDbContext dbContext;

        public CountryRepository(LingoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        //Create--------------------------------
        public async Task<Country> CreateAsync(Country country)
        {
            await dbContext.Countries.AddAsync(country);
            dbContext.SaveChanges();

            return country;
        }


        //Delete-------------------------------

        public async Task<Country> DeleteAsync(Guid id)
        {
            var country = await dbContext.Countries.FirstOrDefaultAsync(c => c.Id == id);

            if (country == null) {

                return null;
            }

            dbContext.Countries.Remove(country);
            dbContext.SaveChanges();

            return country;
        }


        //Read------------------------------
        public async Task<List<Country>> GetAllAsync(string? filterOn, string? filterQuery, string? sortBy, bool isAscending = true,
            int pageNumber = 1, int pageSize = 5)
        {
           
            var country = dbContext.Countries.AsQueryable();

            //Filtering-------

            if(string.IsNullOrWhiteSpace(filterOn)==false && string.IsNullOrWhiteSpace(filterQuery) == false)
            {
                if (filterOn.Equals("CodeName", StringComparison.OrdinalIgnoreCase))
                {
                    country = country.Where(x=> x.CodeName.Contains(filterQuery));
                }
            }


            //Sorting---------

            if (string.IsNullOrWhiteSpace(sortBy) == false)
            {
                if (sortBy.Equals("CodeName", StringComparison.OrdinalIgnoreCase))
                {
                    country = isAscending ? country.OrderBy(x=>x.CodeName) : country.OrderByDescending(x=>x.CodeName);

                }else if (sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    country = isAscending ? country.OrderBy(x => x.Name) : country.OrderByDescending(x => x.Name);
                }
                
            }

            //Pagination-------

            var skipResults = (pageNumber - 1) * pageSize;

            return await country.Skip(skipResults).Take(pageSize).ToListAsync();
        }

        public async Task<Country> GetByIdAsync(Guid id)
        {
            var country = await dbContext.Countries.FirstOrDefaultAsync(x=>x.Id==id);
            if (country == null) { 
                return null;
            }
            return country;
        }

        //Update-----------------------------
        public async Task<Country> UpdateAsync(Guid id,Country country)
        {
            var existCountry = await dbContext.Countries.FirstOrDefaultAsync(x=>x.Id==id);

            if (existCountry == null) {
                return null;
            }

            existCountry.Name = country.Name;
            existCountry.CodeName = country.CodeName;

            dbContext.SaveChanges();

            return existCountry;
        }


        


    }
}
