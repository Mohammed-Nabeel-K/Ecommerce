using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Data.config
{
    public class userConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder) {
            builder.HasData(new List<User>
            {
                new User {
                    user_id = 1,
                    username = "admin",
                    Name ="admin",
                    Email = "admin@gmail.com",
                    phoneNumber = "9876543210",
                    Password = "admin"
                }
            });

            builder.HasKey(e => e.user_id);

           

        }
    }
}
