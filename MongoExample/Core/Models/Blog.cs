using MongoDB.Bson;

namespace MongoExample.Core.Models;

public class Blog
{
    public ObjectId Id { get; set; }
    public string Title { get; set; }
    public ObjectId UserId { get; set; }
    public List<string>? postIds { get; set; }
}