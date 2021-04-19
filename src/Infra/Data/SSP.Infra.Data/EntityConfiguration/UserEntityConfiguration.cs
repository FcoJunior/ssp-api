using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SSP.Infra.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace SSP.Infra.Data.EntityConfiguration
{
    public class UserEntityConfiguration : EntityConfigurationBase<UserEntity>
    {
        public override void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            base.Configure(builder);
            builder.ToTable("Usuario", schema: "dbo");

            builder.Property(x => x.Name)
                .HasColumnName("Nome")
                .HasMaxLength(50)
                .IsRequired();
            
            builder.Property(x => x.Cpf)
                .HasColumnName("CPF")
                .HasMaxLength(11)
                .IsRequired();

            builder.Property(x => x.Email)
                .HasColumnName("Email")
                .HasMaxLength(25)
                .IsRequired();

            builder.Property(x => x.CreationDate)
                .HasColumnName("DataCriacao")
                .IsRequired();

            builder.Property(x => x.Enable)
                .HasColumnName("Ativo")
                .IsRequired();

            builder.Property(x => x.Password)
                .HasColumnName("Senha")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.ProfileId)
                .HasColumnName("PerfilId")
                .HasMaxLength(36)
                .IsRequired();

            builder.HasIndex(x => x.Cpf)
                .IsUnique();
            
            builder.HasIndex(x => x.Email)
                .IsUnique();

            builder.HasOne(x => x.Profile)
                .WithMany(x => x.Users)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.ProfileId);
            
        }
    }
}