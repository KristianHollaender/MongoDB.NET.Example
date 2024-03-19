using Microsoft.AspNetCore.Mvc;
using MongoExample.Core.Models;
using MongoExample.Core.Services;

namespace MongoExample.Controllers;

[ApiController]
[Route("[controller]")]
public class CommentController : ControllerBase
{
    private readonly CommentService _commentService;
    
    public CommentController(CommentService commentService)
    {
        _commentService = commentService;
    }
    
    [HttpGet]
    public Comment GetCommentById(string id)
    {
        return _commentService.GetComment(id);
    }
    
    [HttpGet("GetComments")]
    public List<Comment> GetComments()
    {
        return _commentService.GetComments();
    }
    
    [HttpPost]
    public void SaveEvent([FromBody] Comment comment)
    {
        _commentService.SaveComment(comment);
    }
    
    [HttpDelete]
    public Comment DeleteCommentById(string id)
    {
        return _commentService.DeleteComment(id);
    }
}