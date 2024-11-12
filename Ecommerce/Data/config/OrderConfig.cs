using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Data.config
{
    public class OrderConfig :IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builderOrder) {
            builderOrder.HasKey(n => n.order_id);
        }
    }
}
