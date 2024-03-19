using MongoExample.Core.Factories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton(WebEventServiceFactory.Create());
builder.Services.AddSingleton(BlogServiceFactory.Create());
builder.Services.AddSingleton(CommentServiceFactory.Create());
builder.Services.AddSingleton(PostServiceFactory.Create());
builder.Services.AddSingleton(UserServiceFactory.Create()); 
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();