using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Register.Infrastructure;

public sealed class Context : DbContext
{
    public Context(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly).Seed();    
}
