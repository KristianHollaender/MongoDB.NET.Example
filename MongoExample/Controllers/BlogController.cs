using Microsoft.AspNetCore.Mvc;
using MongoExample.Core.Models;
using MongoExample.Core.Services;

namespace MongoExample.Controllers;

[ApiController]
[Route("[controller]")]
public class BlogController : ControllerBase
{
    private readonly BlogService _blogService;
    
    public BlogController(BlogService blogService)
    {
        _blogService = blogService;
    }
    
    [HttpGet]
    public Blog GetEventById(string id)
    {
        return _blogService.GetBlog(id);
    }
    
    [HttpGet("GetBLogs")]
    public List<Blog> GetBlogs()
    {
        return _blogService.GetBlogs();
    }
    
    [HttpPost]
    public void SaveEvent([FromBody] Blog blog)
    {
        _blogService.SaveBlog(blog);
    }

    [HttpDelete]
    public Blog DeleteBlogById(string id)
    {
        return _blogService.DeleteBlog(id);
    }
}