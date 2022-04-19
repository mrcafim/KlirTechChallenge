using Klir.TechChallenge.Web.Domain.Product.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Klir.TechChallenge.Web.Infra.Data.Mappings
{
    public class ProductPromotionMap : IEntityTypeConfiguration<ProductPromotion>
    {
        public void Configure(EntityTypeBuilder<ProductPromotion> builder)
        {
            builder.ToTable("ProductPromotion");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id);

            builder.Property(x => x.Description)
                .HasColumnType("varchar(100)")
                .HasColumnName("Description")
                .IsRequired();

            builder.Property(x => x.MinimumQuantity)
                .IsRequired();

            builder.Property(x => x.Discount)
                .IsRequired()
                .HasColumnType($"decimal(10,2)");

            builder.Property(x => x.Active)
                .IsRequired();

        }
    }
}
