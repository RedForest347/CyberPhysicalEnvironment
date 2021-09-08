using Microsoft.EntityFrameworkCore;
using Core.Domain;

namespace Core.Infrastructure
{
    public class Context : DbContext
    {

        public Context(DbContextOptions<Context> options)
            : base(options) { }

        public DbSet<Agent> Agents { get; set; }
        public DbSet<AgentType> AgentTypes { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<LinkType> LinkTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Link>()
                .Property(b => b.Id)
                .ValueGeneratedNever();

            modelBuilder.Entity<LinkType>()
                .Property(b => b.Id)
                .ValueGeneratedNever();

            modelBuilder.Entity<Agent>()
                .Property(b => b.Id)
                .ValueGeneratedNever();

            modelBuilder.Entity<AgentType>()
                .Property(b => b.Id)
                .ValueGeneratedNever();

            modelBuilder.Entity<Link>()
           .HasOne(l => l.Agent1)
           .WithMany(a => a.OutputLinks)
           .HasForeignKey(l => l.Agent1Id)
           .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Link>()
           .HasOne(l => l.Agent2)
           .WithMany(a => a.InputLinks)
           .HasForeignKey(l => l.Agent2Id)
           .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Agent>()
           .HasOne(l => l.AgentType)
           .WithMany(a => a.Agents)
           .HasForeignKey(l => l.AgentTypeId)
           .IsRequired(false);

            modelBuilder.Entity<Link>()
           .HasOne(l => l.LinkType)
           .WithMany(a => a.Links)
           .HasForeignKey(l => l.LinkTypeId)
           .IsRequired(false);

        }
    }
}
