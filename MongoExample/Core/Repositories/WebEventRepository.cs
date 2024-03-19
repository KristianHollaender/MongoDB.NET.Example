using MongoDB.Bson;
using MongoDB.Driver;
using MongoExample.Core.Models;
using MongoExample.Core.MongoClient;

namespace MongoExample.Core.Repositories;

public class WebEventRepository
{
    private readonly Client _client;
    private readonly string _databaseName;
    private readonly string _collectionName;
    
    public WebEventRepository(Client client, string databaseName = "events", string collectionName = "webEvents")
    {
        _client = client;
        _databaseName = databaseName;
        _collectionName = collectionName;
    }

    public WebEventModel GetById(string id)
    {
        var objectId = new ObjectId(id);
        var collection = _client.Collection<WebEventModel>(_databaseName, _collectionName);
        
        return collection.Find(x => x._id == objectId).FirstOrDefault();
    }
    
    public List<WebEventModel> GetEvents()
    {
        var collection = _client.Collection<WebEventModel>(_databaseName, _collectionName);
            
        return collection.Find(_ => true).ToList();
    }

    public void InsertOne(WebEventModel item)
    {
        var collection = _client.Collection<WebEventModel>(_databaseName, _collectionName);
        collection.InsertOne(item);
    }
    
    public void InsertMany(IEnumerable<WebEventModel> items)
    {
        var collection = _client.Collection<WebEventModel>(_databaseName, _collectionName);
        collection.InsertMany(items);
    }
}