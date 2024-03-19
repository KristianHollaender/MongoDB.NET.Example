using MongoExample.Core.MongoClient;
using MongoExample.Core.Repositories;
using MongoExample.Core.Services;

namespace MongoExample.Core.Factories;

public static class WebEventServiceFactory
{
    public static WebEventService Create()
    {
        var client = new Client("mongodb://localhost:27017");
        var repository = new WebEventRepository(client);
        return new WebEventService(repository);
    }
}