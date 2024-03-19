using Microsoft.AspNetCore.Mvc;
using MongoExample.Core.Models;
using MongoExample.Core.Services;

namespace MongoExample.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly UserService _userService;
    
    public UserController(UserService userService)
    {
        _userService = userService;
    }
    
    [HttpGet]
    public User GetUserById(string id)
    {
        return _userService.GetUser(id);
    }
    
    [HttpGet("GetUsers")]
    public List<User> GetUsers()
    {
        return _userService.GetUsers();
    }
    
    [HttpPost]
    public void SaveEvent([FromBody] User user)
    {
        _userService.SaveUser(user);
    }
    
    [HttpDelete]
    public User DeleteUserById(string id)
    {
        return _userService.DeleteUser(id);
    }
}