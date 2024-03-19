using MongoDB.Bson;
using MongoDB.Driver;
using MongoExample.Core.Models;
using MongoExample.Core.MongoClient;

namespace MongoExample.Core.Repositories;

public class PostRepository
{
    private readonly Client _client;
    private readonly string _databaseName;
    private readonly string _collectionName;

    public PostRepository(Client client, string databaseName = "blogging", string collectionName = "posts")
    {
        _client = client;
        _databaseName = databaseName;
        _collectionName = collectionName;
    }

    public Post GetById(string id)
    {
        var objectId = new ObjectId(id);
        var collection = _client.Collection<Post>(_databaseName, _collectionName);

        return collection.Find(x => x.Id == objectId).FirstOrDefault();
    }

    public List<Post> GetPosts()
    {
        var collection = _client.Collection<Post>(_databaseName, _collectionName);

        return collection.Find(_ => true).ToList();
    }

    public void InsertOne(Post item)
    {
        var collection = _client.Collection<Post>(_databaseName, _collectionName);
        collection.InsertOne(item);
    }

    public void InsertMany(IEnumerable<Post> items)
    {
        var collection = _client.Collection<Post>(_databaseName, _collectionName);
        collection.InsertMany(items);
    }

    public Post DeleteOne(string id)
    {
        var objectId = new ObjectId(id);
        var collection = _client.Collection<Post>(_databaseName, _collectionName);

        var deletedPost = collection.FindOneAndDelete(x => x.Id == objectId);
        return deletedPost;
    }

    public Post UpdateOne(string id, Post updatedPost)
    {
        var objectId = new ObjectId(id);
        var collection = _client.Collection<Post>(_databaseName, _collectionName);

        var filter = Builders<Post>.Filter.Eq(p => p.Id, objectId);
        var update = Builders<Post>.Update
            .Set(p => p.Title, updatedPost.Title)
            .Set(p => p.Content, updatedPost.Content)
            .Set(p => p.UserId, updatedPost.UserId)
            .Set(p => p.BlogID, updatedPost.BlogID);

        var options = new FindOneAndUpdateOptions<Post>
        {
            ReturnDocument = ReturnDocument.After
        };


        var postToUpdate = collection.FindOneAndUpdate(filter, update, options);

        return postToUpdate;
    }
}