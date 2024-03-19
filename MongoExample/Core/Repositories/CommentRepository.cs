using MongoDB.Bson;
using MongoDB.Driver;
using MongoExample.Core.Models;
using MongoExample.Core.MongoClient;

namespace MongoExample.Core.Repositories;

public class CommentRepository
{
    private readonly Client _client;
    private readonly string _databaseName;
    private readonly string _collectionName;
    
    public CommentRepository(Client client, string databaseName = "blogging", string collectionName = "comments")
    {
        _client = client;
        _databaseName = databaseName;
        _collectionName = collectionName;
    }
    
    public Comment GetById(string id)
    {
        var objectId = new ObjectId(id);
        var collection = _client.Collection<Comment>(_databaseName, _collectionName);
        
        return collection.Find(x => x.Id == objectId).FirstOrDefault();
    }
    
    public List<Comment> GetComments()
    {
        var collection = _client.Collection<Comment>(_databaseName, _collectionName);
            
        return collection.Find(_ => true).ToList();
    }

    public void InsertOne(Comment comment)
    {
        // Insert the comment into the comments collection
        var commentsCollection = _client.Collection<Comment>(_databaseName, _collectionName);
        commentsCollection.InsertOne(comment);

        // Retrieve the post the comment belongs to
        var postsCollection = _client.Collection<Post>(_databaseName, "posts");
        var post = postsCollection.Find(x => x.Id == new ObjectId(comment.PostId)).FirstOrDefault();

        // Update the post's CommentIds list
        if (post != null)
        {
            post.CommentIds.Add(comment.Id);
            postsCollection.ReplaceOne(x => x.Id == post.Id, post);
        }
    }
    
    public void InsertMany(IEnumerable<Comment> items)
    {
        var collection = _client.Collection<Comment>(_databaseName, _collectionName);
        collection.InsertMany(items);
    }
    
    public Comment DeleteOne(string id)
    {
        var objectId = new ObjectId(id);
        var collection = _client.Collection<Comment>(_databaseName, _collectionName);

        var deletedComment = collection.FindOneAndDelete(x => x.Id == objectId);
        return deletedComment;
    }
}