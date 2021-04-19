using SSP.Infra.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SSP.Infra.Data.EntityConfiguration
{
    public class ProfileEntityConfiguration : EntityConfigurationBase<ProfileEntity>
    {
        public override void Configure(EntityTypeBuilder<ProfileEntity> builder)
        {
            base.Configure(builder);
            builder.ToTable("Perfil", schema: "dbo");

            builder.Property(x => x.Name)
                .HasColumnName("Nome")
                .HasMaxLength(30)
                .IsRequired();
        }
    }
}