using System;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace RepositoryWithCompositeKeys
{
    public class CompositeKeyContext : DbContext
    {
        public DbSet<Order> Orders { get; set; } = null!;

        public CompositeKeyContext()
            : base(new DbContextOptionsBuilder<CompositeKeyContext>().UseSqlServer("data source=localhost;initial catalog=EF;Integrated Security=true;").Options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("compkey");

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(OrderConfiguration)));
        }
    }
}