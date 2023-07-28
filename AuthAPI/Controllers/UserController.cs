using AuthAPI.Data.DTO;
using AuthAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
namespace AuthAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private IMapper _map;
    private UserManager<User> _userManager;
    public UserController(IMapper map, UserManager<User> um)
    {
        _map = map;
        _userManager = um;
    }
    [HttpPost]
    public async Task<IActionResult> RegisterUser(CreateUserDTO dto)
    {
        var user = _map.Map<User>(dto);
        var res = await _userManager.CreateAsync(user, dto.Password);
        if (res.Succeeded)
        {
            return Ok("User registered!");
        }
        else
        {
            //foreach (var err in res.Errors)
            //{
            //    Console.WriteLine(err.Description);
            //}
            var app = new ApplicationException();
            throw new ApplicationException(app.Message);
        }
    }
}
