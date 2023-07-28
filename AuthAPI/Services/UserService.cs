using AuthAPI.Data.DTO;
using AuthAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AuthAPI.Services;

/// <summary>
/// Lida com as operações de login e cadastro de usuário.
/// </summary>
public class UserService
{
    private IMapper _map;
    private UserManager<User> _uManager;
    private SignInManager<User> _signManager;
    private TokenService _tokenService;

    public UserService(IMapper map, UserManager<User> um, SignInManager<User> signManager, TokenService tokenService)
    {
        _map = map;
        _uManager = um;
        _signManager = signManager;
        _tokenService = tokenService;
    }

    public async Task Login(LoginUserDTO dto)
    {
        var res = await _signManager.PasswordSignInAsync(dto.Username, dto.Password, true, false);
        if (!res.Succeeded)
        {
            var app = new ApplicationException();
            throw new ApplicationException(app.Message);
        }
        else
        {
            //_tokenService.GenerateToken(user);
        }
    }

    public async Task AddUser(CreateUserDTO dto)
    {
        var user = _map.Map<User>(dto);
        var res = await _uManager.CreateAsync(user, dto.Password);
        if (res.Errors.Any())
        {
            foreach (var error in res.Errors)
            {
                Console.WriteLine(error);
            }
            var app = new ApplicationException();
            throw new ApplicationException(app.Message);
        }
    }
}
