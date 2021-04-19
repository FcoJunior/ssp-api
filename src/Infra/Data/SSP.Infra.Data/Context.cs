using System;
using Microsoft.EntityFrameworkCore;
using SSP.Infra.Data.Entity;
using SSP.Infra.Data.EntityConfiguration;

namespace SSP.Infra.Data
{
    public class Context : DbContext, IContext
    {
        public Context() { }
        public Context(DbContextOptions<Context> options)
            : base(options) {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ProfileEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
        }

        public DbSet<UserEntity> User { get; set; }
        public DbSet<ProfileEntity> Profile { get; set; }
    }
}
