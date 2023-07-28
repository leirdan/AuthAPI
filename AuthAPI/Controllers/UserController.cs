using AuthAPI.Data.DTO;
using Microsoft.AspNetCore.Mvc;
namespace AuthAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    public IActionResult RegisterUser(CreateUserDTO user)
    {
        throw new NotImplementedException();
    }
}
