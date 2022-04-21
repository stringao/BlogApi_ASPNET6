using Blog.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers;

[ApiController]
[Route("")]
public class HomeController : ControllerBase
{
    //[HttpGet("health-check")]
    [HttpGet("")]
    // [ApiKey] Exemplo de atributo para fazer ByPass da autorização
    public IActionResult Get()
    {
        return Ok("API Online");
    }
}
