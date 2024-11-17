using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Data.config
{
    public class AddressConfig : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder) {
            builder.HasKey(n => n.address_id);

            builder.HasOne(n => n.user)
                .WithMany(n => n.addresses)
                .HasForeignKey(n => n.user_id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
