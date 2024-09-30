using WebAPI;
using WebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton(new DatabaseService(builder.Configuration.GetConnectionString("QuizConnectionString")));

var app = builder.Build();

// configure app
app.Configure();
app.Run();
