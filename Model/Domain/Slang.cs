namespace Lingo.Model.Domain
{
    public class Slang
    {
        public Guid Id { get; set; }
        public string  Word { get; set; }
        public string Meaning { get; set; }

        public Guid StrongLevelId { get; set; }

        public  Guid CountryId { get; set; }

        public Guid ContinentId { get; set; }



        //Navigation Properties

        public StrongLevel StrongLevel { get; set; }

        public Country Country { get; set; }

        public  Continent Continent { get; set; }

        


    }
}
