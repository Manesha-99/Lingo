using System.ComponentModel.DataAnnotations;

namespace Lingo.Model.Dto
{
    public class RegisterAuthDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public string [] Roles { get; set; }
    }
}
