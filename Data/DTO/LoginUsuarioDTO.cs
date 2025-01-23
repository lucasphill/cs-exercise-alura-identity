using System.ComponentModel.DataAnnotations;

namespace Identity.API.Data.DTO
{
    public class LoginUsuarioDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
