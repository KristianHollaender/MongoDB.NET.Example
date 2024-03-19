﻿using MongoExample.Core.MongoClient;
using MongoExample.Core.Repositories;
using MongoExample.Core.Services;

namespace MongoExample.Core.Factories;

public class BlogServiceFactory
{
    public static BlogService Create()
    {
        var client = new Client("mongodb://localhost:27017");
        var repository = new BlogRepository(client);
        return new BlogService(repository);
    }
}