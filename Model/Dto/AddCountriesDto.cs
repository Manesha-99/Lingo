using System.ComponentModel.DataAnnotations;

namespace Lingo.Model.Dto
{
    public class AddCountriesDto
    {
        [Required]
        public string Name { get; set; }

        public string CodeName { get; set; }
    }
}
