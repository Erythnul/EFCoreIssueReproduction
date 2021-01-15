using System;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace RepositoryWithNoCompositeKeys
{
    public class NoCompositeKeyContext : DbContext
    {
        public DbSet<Order> Orders { get; set; } = null!;

        public NoCompositeKeyContext()
            : base(new DbContextOptionsBuilder<NoCompositeKeyContext>().UseSqlServer("data source=localhost;initial catalog=EF;Integrated Security=true;").Options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("nocompkey");

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(OrderConfiguration)));
        }
    }
}