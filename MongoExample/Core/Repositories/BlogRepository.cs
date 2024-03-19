using MongoDB.Bson;
using MongoDB.Driver;
using MongoExample.Core.Models;
using MongoExample.Core.MongoClient;

namespace MongoExample.Core.Repositories;

public class BlogRepository
{
    private readonly Client _client;
    private readonly string _databaseName;
    private readonly string _collectionName;

    public BlogRepository(Client client, string databaseName = "blogging", string collectionName = "blogs")
    {
        _client = client;
        _databaseName = databaseName;
        _collectionName = collectionName;
    }

    public Blog GetById(string id)
    {
        var objectId = new ObjectId(id);
        var collection = _client.Collection<Blog>(_databaseName, _collectionName);

        return collection.Find(x => x.Id == objectId).FirstOrDefault();
    }

    public List<Blog> GetBlogs()
    {
        var collection = _client.Collection<Blog>(_databaseName, _collectionName);

        return collection.Find(_ => true).ToList();
    }

    public void InsertOne(Blog item)
    {
        var collection = _client.Collection<Blog>(_databaseName, _collectionName);
        collection.InsertOne(item);
    }

    public void InsertMany(IEnumerable<Blog> items)
    {
        var collection = _client.Collection<Blog>(_databaseName, _collectionName);
        collection.InsertMany(items);
    }

    public Blog DeleteOne(string id)
    {
        var objectId = new ObjectId(id);
        var collection = _client.Collection<Blog>(_databaseName, _collectionName);

        var deletedBlog = collection.FindOneAndDelete(x => x.Id == objectId);
        return deletedBlog;
    }
}