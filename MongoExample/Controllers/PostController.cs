using Microsoft.AspNetCore.Mvc;
using MongoExample.Core.Models;
using MongoExample.Core.Services;

namespace MongoExample.Controllers;

[ApiController]
[Route("[controller]")]
public class PostController : ControllerBase
{
    private readonly PostService _postService;
    
    public PostController(PostService postService)
    {
        _postService = postService;
    }
    
    [HttpGet]
    public Post GetEventById(string id)
    {
        return _postService.GetPost(id);
    }
    
    [HttpGet("GetPosts")]
    public List<Post> GetPosts()
    {
        return _postService.GetPosts();
    }
    
    [HttpPost]
    public void SaveEvent([FromBody] Post post)
    {
        _postService.SavePost(post);
    }
    
    [HttpDelete]
    public Post DeletePostById(string id)
    {
        return _postService.DeletePost(id);
    }
}