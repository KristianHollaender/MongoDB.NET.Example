using MongoExample.Core.MongoClient;
using MongoExample.Core.Repositories;
using MongoExample.Core.Services;

namespace MongoExample.Core.Factories;

public class CommentServiceFactory
{
    public static CommentService Create()
    {
        var client = new Client("mongodb://localhost:27017");
        var repository = new CommentRepository(client);
        return new CommentService(repository);
    }
}