using MongoDB.Bson;

namespace MongoExample.Core.Models;


public class Comment
{
    public ObjectId Id { get; set; }
    public string Content { get; set; }
    public string UserId { get; set; }
    public string PostId { get; set; }
}