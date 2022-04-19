using Klir.TechChallenge.Web.Domain.Cart.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Klir.TechChallenge.Web.Infra.Data.Mappings
{
    public class CartItemMap : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.ToTable("CartItem");

            builder.Property(x => x.Id);

            builder.HasKey(x => new { x.Id, x.ProductId });

            builder.Property(x => x.Quantity)
                .IsRequired();

        }
    }
}
