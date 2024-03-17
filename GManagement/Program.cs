using GManagement.DbTest;
using GManagement.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/games", () => GameDb.Get());
app.MapPost("/games", (Game game) => GameDb.Post(game));
app.MapPut("/games/{id}", (Game game, int id) => GameDb.Put(game, id));
app.MapDelete("/games/{id}", (int id) => GameDb.Delete(id));

app.UseHttpsRedirection();

app.Run();