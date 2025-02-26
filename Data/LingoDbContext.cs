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
        public DbSet<StrongLevel> StrongLevels { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Continent> Continents { get; set; }



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
                    Id= Guid.Parse("35aa616e-9d5a-411c-bb33-04a7ec0b2281"),
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
                    StrongLevelId = Guid.Parse("0CBE9559-F6D8-4E69-9AD7-16CA9560BD17"),
                    CountryId = Guid.Parse("363BF2CE-A988-4B0A-88E5-12034F6C6AA5"),
                    ContinentId = Guid.Parse("35AA616E-9D5A-411C-BB33-04A7EC0B2281")
                },
                new Slang()
                {
                    Id = Guid.Parse("5a3c1374-9f3c-4a96-a555-566403c28973"),
                    Word = "Cap",
                    Meaning = "Means a lie",
                    StrongLevelId = Guid.Parse("1C8B6236-74F1-40AC-A127-A0F8B572432B"),
                    CountryId = Guid.Parse("363bf2ce-a988-4b0a-88e5-12034f6c6aa5"),
                    ContinentId = Guid.Parse("35aa616e-9d5a-411c-bb33-04a7ec0b2281")
                },
                new Slang()
                {
                    Id = Guid.Parse("0854b55b-dfc4-4b44-9efc-32a9d883b88a"),
                    Word = "Knackered",
                    Meaning = "Extremely tired or exhausted",
                    StrongLevelId = Guid.Parse("0CBE9559-F6D8-4E69-9AD7-16CA9560BD17"),
                    CountryId = Guid.Parse("947664B6-25A2-42AD-B920-B427391B97B6"),
                    ContinentId = Guid.Parse("C8841377-D6A4-477E-8102-08FC0EDC7CEC")
                },
                new Slang()
                {
                    Id = Guid.Parse("2f66ce89-bb29-49da-92de-e645dfcb8fab"),
                    Word = "Faggot",
                    Meaning = "A gay man",
                    StrongLevelId = Guid.Parse("D44ED0A3-72F8-4E8C-810B-3DBB270366D5"),
                    CountryId = Guid.Parse("363bf2ce-a988-4b0a-88e5-12034f6c6aa5"),
                    ContinentId = Guid.Parse("35aa616e-9d5a-411c-bb33-04a7ec0b2281")
                },
                new Slang()
                {
                    Id = Guid.Parse("84e55f54-2214-4145-8cf3-ee28943fc189"),
                    Word = "làiháma",
                    Meaning = "An Ugly Boy",
                    StrongLevelId = Guid.Parse("0CBE9559-F6D8-4E69-9AD7-16CA9560BD17"),
                    CountryId = Guid.Parse("8F348057-B5F9-4F47-85B2-8CE65A91B7BB"),
                    ContinentId = Guid.Parse("5C97203C-30AF-48E7-993A-29A316FAB220")
                },
                new Slang()
                {
                    Id = Guid.Parse("a6b4703b-4a0e-4a7b-9ffd-9bdca7a9338b"),
                    Word = "ID photo",
                    Meaning = "the washing of your face and teeth only, instead of your whole body ",
                    StrongLevelId = Guid.Parse("0CBE9559-F6D8-4E69-9AD7-16CA9560BD17"),
                    CountryId = Guid.Parse("9ED2D84B-BD42-4D20-965E-01E147F8C3C0"),
                    ContinentId = Guid.Parse("A5F9D466-B3AC-4E80-9C6A-2730626DCE25")
                },
                new Slang()
                {
                    Id = Guid.Parse("329eb9d0-147b-4467-b680-b8e52e9a2d76"),
                    Word = "Meno male",
                    Meaning = "Means that's good or thank God",
                    StrongLevelId = Guid.Parse("0CBE9559-F6D8-4E69-9AD7-16CA9560BD17"),
                    CountryId = Guid.Parse("9811952C-744C-4BAE-91B3-14B4A4D2EE3E"),
                    ContinentId = Guid.Parse("C8841377-D6A4-477E-8102-08FC0EDC7CEC")
                }

            };

            modelBuilder.Entity<Slang>().HasData(slangs);

        }


    }
}
