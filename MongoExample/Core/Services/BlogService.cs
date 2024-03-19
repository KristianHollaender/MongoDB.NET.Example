using MongoExample.Core.Models;
using MongoExample.Core.Repositories;

namespace MongoExample.Core.Services;

public class BlogService
{
    private readonly BlogRepository _blogRepository;
    
    public BlogService(BlogRepository blogRepository)
    {
        _blogRepository = blogRepository;
    }
    
    public Blog GetBlog(string id){
        return _blogRepository.GetById(id);
    }
    
    public List<Blog> GetBlogs(){
        return _blogRepository.GetBlogs();
    }
    
    public void SaveBlog(Blog blog){
        _blogRepository.InsertOne(blog);
    }
    
    public void SaveBlogs(IEnumerable<Blog> blogs){
        _blogRepository.InsertMany(blogs);
    }
    
    public Blog DeleteBlog(string id)
    {
        return _blogRepository.DeleteOne(id);
    }
}