using System.ComponentModel.DataAnnotations;

namespace CasgemMicroservice.IdentityServer.Dtos
{
    public class SignUpDto
    {
        [Required]
        public string NameSurname { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
