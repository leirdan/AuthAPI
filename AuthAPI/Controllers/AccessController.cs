using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class AccessController : ControllerBase
{
    [HttpGet]
    [Authorize(Policy = "Idade Mínima")] // Indica que só usuários autorizados podem acessar o método.
    public IActionResult Get()
    {
        return Ok("Acesso permitido.");
    }

}
