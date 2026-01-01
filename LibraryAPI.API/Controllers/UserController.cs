using Microsoft.AspNetCore.Mvc;
using LibraryAPI.Application.Interfaces;
using LibraryAPI.Domain.Entities;



[ApiController]
[Route("api/users")]


public class UserController : ControllerBase
{
    private readonly IUserRepository _repository;
    public UserController(IUserRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _repository.GetAllAsync();
        return Ok(users);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] User user)
    {
        await _repository.AddAsync(user);
        return CreatedAtAction(nameof(GetAllUsers), new { id = user.Id }, user);
    }
    
}