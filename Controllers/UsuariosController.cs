using AutoMapper;
using Identity.API.Data.DTO;
using Identity.API.Models;
using Identity.API.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Identity.API.Controllers;

[Route("[controller]")]
[ApiController]
public class UsuariosController : ControllerBase
{
    private UsuarioService _usuarioService;

    public UsuariosController(UsuarioService cadastroService)
    {
        _usuarioService = cadastroService;
    }

    [HttpPost("cadastro")]
    public async Task<IActionResult> CadastraUsuario(CreateUsuarioDTO usuarioDTO)
    {
        await _usuarioService.Cadastra(usuarioDTO);
        return Ok("Usuário cadastrado");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginUsuarioDTO usuarioDTO)
    {
        var token = await _usuarioService.Login(usuarioDTO);
        return Ok(token);
    }
}
