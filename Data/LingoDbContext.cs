using System.Runtime.CompilerServices;
using Lingo.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace Lingo.Data
{
    public class LingoDbContext: DbContext
    {
        public LingoDbContext(DbContextOptions<LingoDbContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<Slang> Slangs { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Continent> Continents { get; set; }
        public DbSet<StrongLevel> StrongLevels { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var stronLevels = new List<StrongLevel>()
            {
                new StrongLevel()
                {
                    Id = Guid.Parse("0cbe9559-f6d8-4e69-9ad7-16ca9560bd17"),
                    Level = "Mild/Casual Slang"
                },
                new StrongLevel()
                {
                    Id= Guid.Parse("1c8b6236-74f1-40ac-a127-a0f8b572432b"),
                    Level = "Moderate Slang"
                },
                new StrongLevel()
                {
                    Id= Guid.Parse("d44ed0a3-72f8-4e8c-810b-3dbb270366d5"),
                    Level = "Strong/Potentially Offensive Slang"
                }
            };

            modelBuilder.Entity<StrongLevel>().HasData(stronLevels);



            var continents = new List<Continent>()
            {
                new Continent()
                {
                    Id= Guid.Parse("5c97203c-30af-48e7-993a-29a316fab220"),
                    Name = "Asia",
                    CodeName = "ASA"
                },
                new Continent()
                {
                    Id= Guid.Parse("a5f9d466-b3ac-4e80-9c6a-2730626dce25"),
                    Name = "Africa",
                    CodeName = "AFA"
                },
                new Continent()
                {
                    Id= Guid.Parse("35aa616e-9d5a-411c-bb33-04a7ec0b22815"),
                    Name = "North America",
                    CodeName = "NAR"
                },
                new Continent()
                {
                    Id= Guid.Parse("d646b273-fcd4-4d5f-8269-5d2a0638dcd2"),
                    Name = "South America",
                    CodeName = "SAR"
                },
                new Continent()
                {
                    Id= Guid.Parse("6c3fe7a0-5b12-4a5e-9435-b6d96edfffe4"),
                    Name = "Antarctica",
                    CodeName = "ATA"
                },
                new Continent()
                {
                    Id= Guid.Parse("c8841377-d6a4-477e-8102-08fc0edc7cec"),
                    Name = "Europe",
                    CodeName = "EUO"
                },
                new Continent()
                {
                    Id= Guid.Parse("caab9054-dc6d-451d-a7ff-64704cf2b8cb"),
                    Name = "Australia",
                    CodeName = "AUS"
                }
            };

            modelBuilder.Entity<Continent>().HasData(continents);



            var countries = new List<Country>()
            {
                new Country()
                {
                    Id = Guid.Parse("363bf2ce-a988-4b0a-88e5-12034f6c6aa5"),
                    Name = "United States America",
                    CodeName = "USA"
                },
                new Country()
                {
                    Id = Guid.Parse("947664b6-25a2-42ad-b920-b427391b97b6"),
                    Name = "United Kingdom",
                    CodeName = "UK"
                },
                new Country()
                {
                    Id = Guid.Parse("9811952c-744c-4bae-91b3-14b4a4d2ee3e"),
                    Name = "Italy",
                    CodeName = "ITA"
                },
                new Country()
                {
                    Id = Guid.Parse("9ed2d84b-bd42-4d20-965e-01e147f8c3c0"),
                    Name = "SouthAfrica",
                    CodeName = "SA"
                },
                new Country()
                {
                    Id = Guid.Parse("8f348057-b5f9-4f47-85b2-8ce65a91b7bb"),
                    Name = "China",
                    CodeName = "CHN"
                },
            };

            modelBuilder.Entity<Country>().HasData(countries);


            var slangs = new List<Slang>()
            {
                new Slang()
                {
                    Id = Guid.Parse("c620e736-31e4-415d-aff4-945c77209f65"),
                    Word = "Lit",
                    Meaning = "Exciting, amazing, or excellent",
                    StrongLevelId = Guid.Parse("0cbe9559-f6d8-4e69-9ad7-16ca9560bd17"),
                    CountryId = Guid.Parse("363bf2ce-a988-4b0a-88e5-12034f6c6aa5"),
                    ContinentId = Guid.Parse("35aa616e-9d5a-411c-bb33-04a7ec0b22815")
                },
                new Slang()
                {
                    Id = Guid.Parse("c620e736-31e4-415d-aff4-945c77209f65"),
                    Word = "Cap",
                    Meaning = "Means a lie",
                    StrongLevelId = Guid.Parse("1c8b6236-74f1-40ac-a127-a0f8b572432b"),
                    CountryId = Guid.Parse("363bf2ce-a988-4b0a-88e5-12034f6c6aa5"),
                    ContinentId = Guid.Parse("35aa616e-9d5a-411c-bb33-04a7ec0b22815")
                },
                new Slang()
                {
                    Id = Guid.Parse("c620e736-31e4-415d-aff4-945c77209f65"),
                    Word = "Knackered",
                    Meaning = "Extremely tired or exhausted",
                    StrongLevelId = Guid.Parse("0cbe9559-f6d8-4e69-9ad7-16ca9560bd17"),
                    CountryId = Guid.Parse("947664b6-25a2-42ad-b920-b427391b97b6"),
                    ContinentId = Guid.Parse("c8841377-d6a4-477e-8102-08fc0edc7cec")
                },
                new Slang()
                {
                    Id = Guid.Parse("c620e736-31e4-415d-aff4-945c77209f65"),
                    Word = "Knackered",
                    Meaning = "Extremely tired or exhausted",
                    StrongLevelId = Guid.Parse("0cbe9559-f6d8-4e69-9ad7-16ca9560bd17"),
                    CountryId = Guid.Parse("947664b6-25a2-42ad-b920-b427391b97b6"),
                    ContinentId = Guid.Parse("c8841377-d6a4-477e-8102-08fc0edc7cec")
                },

            };
        }

    }
}
