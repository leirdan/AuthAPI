using AuthAPI.Data.DTO;
using AuthAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace AuthAPI.Services;

public class RegisterService
{
    private IMapper _map;
    private UserManager<User> _uManager;
    public RegisterService(IMapper map, UserManager<User> um)
    {
        _map = map;
        _uManager = um;
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
