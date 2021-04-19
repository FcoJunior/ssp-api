using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SSP.Infra.Data.Entity;

namespace SSP.Infra.Data.EntityConfiguration
{
    public abstract class EntityConfigurationBase<TEntity> : IEntityTypeConfiguration<TEntity> 
        where TEntity : EntityBase
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .HasMaxLength(36)
                .HasDefaultValueSql("NEWID()")
                .IsRequired();
        }
    }
}