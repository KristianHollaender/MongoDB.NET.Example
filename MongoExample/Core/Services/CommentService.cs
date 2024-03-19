using MongoExample.Core.Models;
using MongoExample.Core.Repositories;

namespace MongoExample.Core.Services;

public class CommentService
{
    private readonly CommentRepository _commentRepository;
    
    public CommentService(CommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }
    
    public Comment GetComment(string id){
        return _commentRepository.GetById(id);
    }
    
    public List<Comment> GetComments(){
        return _commentRepository.GetComments();
    }
    
    public void SaveComment(Comment comment){
        _commentRepository.InsertOne(comment);
    }
    
    public void SaveComments(IEnumerable<Comment> comments){
        _commentRepository.InsertMany(comments);
    }
    
    public Comment DeleteComment(string id)
    {
        return _commentRepository.DeleteOne(id);
    }
}