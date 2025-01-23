using Microsoft.AspNetCore.Identity;

namespace Identity.API.Models;

public class Usuario : IdentityUser
{
    public DateTime DataNascimento { get; set; }
    public DateTime DataCadastro { get; set; } = DateTime.UtcNow;

    public Usuario() : base() {  }
}
