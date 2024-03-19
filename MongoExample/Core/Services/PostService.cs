using MongoExample.Core.Models;
using MongoExample.Core.Repositories;

namespace MongoExample.Core.Services;

public class PostService
{
    private readonly PostRepository _postRepository;
    
    public PostService(PostRepository postRepository)
    {
        _postRepository = postRepository;
    }
    
    public Post GetPost(string id){
        return _postRepository.GetById(id);
    }
    
    public List<Post> GetPosts(){
        return _postRepository.GetPosts();
    }
    
    public void SavePost(Post post){
        _postRepository.InsertOne(post);
    }
    
    public void SavePosts(IEnumerable<Post> posts){
        _postRepository.InsertMany(posts);
    }
    
    public Post DeletePost(string id)
    {
        return _postRepository.DeleteOne(id);
    }

    public Post UpdatePost(string id, Post post)
    {
        return _postRepository.UpdateOne(id, post);
    }
}