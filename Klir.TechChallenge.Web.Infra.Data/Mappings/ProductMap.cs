using Klir.TechChallenge.Web.Domain.Product.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Klir.TechChallenge.Web.Infra.Data.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id);

            builder.Property(x => x.Name)
                .HasColumnType("varchar(100)")
                .HasColumnName("Name")
                .IsRequired();

            builder.Property(x => x.Price)
                .IsRequired()
                .HasColumnType($"decimal(10,2)");

            builder.Property(x => x.Deleted).IsRequired();

            builder.HasOne(x => x.Promotion);
        }
    }
}
