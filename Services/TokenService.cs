using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Identity.API.Models;
using Microsoft.IdentityModel.Tokens;

namespace Identity.API.Services;

public class TokenService
{
    public string TokenGenerate(Usuario usuario)
    {
        Claim[] claims = new Claim[]
        {
            new Claim("Username", usuario.UserName),
            new Claim("Id", usuario.Id),
            new Claim(ClaimTypes.DateOfBirth, usuario.DataNascimento.ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("S4!@56L45K#$%AH56JD2l1kd7hsa45s12afa+++sASKLD)(*&--ASDlska346/*-+5jda"));
        var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken
            (
                expires: DateTime.Now.AddMinutes(10),
                claims: claims,
                signingCredentials: signingCredentials
            );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}