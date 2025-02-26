using System.ComponentModel.DataAnnotations;

namespace Lingo.Model.Dto
{
    public class AddSlangRequestDto
    {
        [Required]
        [DataType(DataType.Text)]
        public string Word { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Meaning { get; set; }

        [Required]
        public Guid StrongLevelId { get; set; }

        [Required]
        public Guid CountryId { get; set; }

        [Required]
        public Guid ContinentId { get; set; }
    }
}
