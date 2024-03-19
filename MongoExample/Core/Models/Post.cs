using MongoDB.Bson;

namespace MongoExample.Core.Models
{
    public class Post
    {
        public ObjectId Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string UserId { get; set; }
        public string BlogID { get; set; }
        public List<ObjectId> CommentIds { get; }
    }
}