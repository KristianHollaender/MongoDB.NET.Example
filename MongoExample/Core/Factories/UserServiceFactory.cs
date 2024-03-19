using MongoExample.Core.MongoClient;
using MongoExample.Core.Repositories;
using MongoExample.Core.Services;

namespace MongoExample.Core.Factories;

public static class UserServiceFactory
{
    public static UserService Create()
    {
        var client = new Client("mongodb://localhost:27017");
        var repository = new UserRepository(client);
        return new UserService(repository);
    }
}