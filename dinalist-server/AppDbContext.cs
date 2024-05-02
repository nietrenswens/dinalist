using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<DiningRoom> DiningRooms { get; set; }
    public DbSet<Token> Tokens { get; set; }

}