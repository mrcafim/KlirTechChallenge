using Klir.TechChallenge.Web.Domain.Cart.Entitities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

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
