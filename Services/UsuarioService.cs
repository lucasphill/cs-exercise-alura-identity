using AutoMapper;
using Identity.API.Data.DTO;
using Identity.API.Models;
using Microsoft.AspNetCore.Identity;

namespace Identity.API.Services;

public class UsuarioService
{
    private IMapper _mapper;
    private UserManager<Usuario> _userMananger;
    private SignInManager<Usuario> _signInMananger;
    private TokenService _tokenService;

    public UsuarioService(IMapper mapper, UserManager<Usuario> userMananger, SignInManager<Usuario> signInMananger, TokenService tokenService)
    {
        _mapper = mapper;
        _userMananger = userMananger;
        _signInMananger = signInMananger;
        _tokenService = tokenService;
    }


    public async Task Cadastra(CreateUsuarioDTO usuarioDTO)
    {
        Usuario usuario = _mapper.Map<Usuario>(usuarioDTO);
        IdentityResult resultado = await _userMananger.CreateAsync(usuario, usuarioDTO.Password);
        if (!resultado.Succeeded) throw new ApplicationException("Falha ao cadastrar usuário");
    }

    public async Task<string> Login(LoginUsuarioDTO usuarioDTO)
    {
        var resultado = await _signInMananger.PasswordSignInAsync(usuarioDTO.Username, usuarioDTO.Password, false, false);
        if (!resultado.Succeeded) throw new ApplicationException("Usuário não autenticado");

        var usuario = _signInMananger.UserManager.Users.FirstOrDefault(u => u.NormalizedUserName == usuarioDTO.Username.ToUpper());

        var token = _tokenService.TokenGenerate(usuario);

        return token;
    }
}
