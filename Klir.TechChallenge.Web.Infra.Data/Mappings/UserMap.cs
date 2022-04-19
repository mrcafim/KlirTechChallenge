using Klir.TechChallenge.Web.Domain.User.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Klir.TechChallenge.Web.Infra.Data.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id);

            builder.Property(x => x.Type);

            builder.Property(x => x.Name)
                .HasColumnType("varchar(100)")
                .HasColumnName("Name")
                .IsRequired();

            builder.Property(x => x.Email)
                 .HasColumnType("varchar(100)")
                 .HasColumnName("Email")
                 .IsRequired();

            builder.Property(x => x.Password)
                .IsRequired();

            builder.Property(x => x.CreatedAt)
                .IsRequired();

            builder.Property(x => x.UpdatedAt)
                .IsRequired();

            builder.Property(x => x.Active).IsRequired();

            builder.Property(x => x.Deleted).IsRequired();

            builder.Property(x => x.CartId);

            builder.HasOne(x => x.Cart);
        }
    }
}
