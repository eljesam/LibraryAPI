namespace LibraryAPI.Controllers;

using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("api/test")]
public class TestController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Library API is running.");
    }
}