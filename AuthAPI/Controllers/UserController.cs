using AuthAPI.Data.DTO;
using AuthAPI.Services;
using Microsoft.AspNetCore.Mvc;
namespace AuthAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private RegisterService _service;
    public UserController(RegisterService ser)
    {
        _service = ser;
    }
    [HttpPost]
    public async Task<IActionResult> RegisterUser(CreateUserDTO dto)
    {
        await _service.AddUser(dto);
        return Ok("User registered!");
    }
}
