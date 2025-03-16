using HangFire.Models;
using Microsoft.EntityFrameworkCore;

namespace HangFire.Context;

public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Employee> Employees { get; set; }
}
