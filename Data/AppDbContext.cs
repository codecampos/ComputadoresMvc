using ComputadoresMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace ComputadoresMvc.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Computador> Computadores => Set<Computador>();
}
