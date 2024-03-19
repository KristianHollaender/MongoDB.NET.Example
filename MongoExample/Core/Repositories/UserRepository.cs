using MongoDB.Bson;
using MongoDB.Driver;
using MongoExample.Core.Models;
using MongoExample.Core.MongoClient;

namespace MongoExample.Core.Repositories;

public class UserRepository
{
    private readonly Client _client;
    private readonly string _databaseName;
    private readonly string _collectionName;
    
    public UserRepository(Client client, string databaseName = "blogging", string collectionName = "users")
    {
        _client = client;
        _databaseName = databaseName;
        _collectionName = collectionName;
    }
    
    public User GetById(string id)
    {
        var objectId = new ObjectId(id);
        var collection = _client.Collection<User>(_databaseName, _collectionName);
        
        return collection.Find(x => x.Id == objectId).FirstOrDefault();
    }
    
    public List<User> GetUsers()
    {
        var collection = _client.Collection<User>(_databaseName, _collectionName);
            
        return collection.Find(_ => true).ToList();
    }

    public void InsertOne(User user)
    {
        var collection = _client.Collection<User>(_databaseName, _collectionName);
        collection.InsertOne(user);
    }
    
    public void InsertMany(IEnumerable<User> users)
    {
        var collection = _client.Collection<User>(_databaseName, _collectionName);
        collection.InsertMany(users);
    }
    
    public User DeleteOne(string id)
    {
        var objectId = new ObjectId(id);
        var collection = _client.Collection<User>(_databaseName, _collectionName);

        var deletedUser = collection.FindOneAndDelete(x => x.Id == objectId);
        return deletedUser;
    }
}