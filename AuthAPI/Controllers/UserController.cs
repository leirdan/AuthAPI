using AuthAPI.Data.DTO;
using AuthAPI.Services;
using Microsoft.AspNetCore.Mvc;
namespace AuthAPI.Controllers;

/// <summary>
/// Lida com as requisições e chama o serviço para realizar as operações. 
/// </summary>
[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private UserService _service;
    public UserController(UserService ser)
    {
        _service = ser;
    }
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginUserDTO dto)
    {
        var token = await _service.Login(dto);
        return Ok("Your token: " + token);
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterUser(CreateUserDTO dto)
    {
        await _service.AddUser(dto);
        return Ok("User registered!");
    }
}
