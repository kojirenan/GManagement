using GManagement.Models;
using GManagement.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Game") ?? "Data Source=Game.db";
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSqlite<GameDb>(connectionString);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/games", async (GameDb db) => await db.Games.ToListAsync());
app.MapGet("/games/{id}", async (GameDb db, int id) => await db.Games.FindAsync(id));
app.MapPost("/games", async (GameDb db, Game game) =>
{
    await db.Games.AddAsync(game);
    await db.SaveChangesAsync();
    return Results.Created();
});
app.MapPut("/games/{id}", async (GameDb db, Game updateGame ,int id) =>
{
    var oldGame = await db.Games.FindAsync(id);
    if (oldGame is null) return Results.NotFound();
    
    db.Entry(oldGame).CurrentValues.SetValues(updateGame);
    await db.SaveChangesAsync();
    return Results.Ok(await db.Games.FindAsync(id));
});
app.MapDelete("/games/{id}", async (GameDb db, int id) =>
{
    var gameToRemove = await db.Games.FindAsync(id);
    if (gameToRemove is null) return Results.NotFound();

    db.Games.Remove(gameToRemove);
    await db.SaveChangesAsync();
    return Results.Ok();
});

app.UseHttpsRedirection();

app.Run();