using GManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace GManagement.Context;

public class GameDb : DbContext
{
    public GameDb(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Game> Games { get; set; } = null;
}