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
        var collection = _client.Collection<Comment>(_databaseName, _collectionName);
        collection.InsertOne(comment);
    }
    
    public void InsertMany(IEnumerable<Comment> comments)
    {
        var collection = _client.Collection<Comment>(_databaseName, _collectionName);
        collection.InsertMany(comments);
    }
    
    public Comment DeleteOne(string id)
    {
        var objectId = new ObjectId(id);
        var collection = _client.Collection<Comment>(_databaseName, _collectionName);

        var deletedComment = collection.FindOneAndDelete(x => x.Id == objectId);
        return deletedComment;
    }
}