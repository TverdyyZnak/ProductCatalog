using Infrastructure.DB.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DB.Options
{
    public class UserActionOptions : IEntityTypeConfiguration<UserActionEntity>
    {
        public void Configure(EntityTypeBuilder<UserActionEntity> builder)
        {
            builder.ToTable("UserActions");

            builder.HasKey(ua => ua.Id);
            builder.HasOne(ua => ua.UserActor);
        }
    }
}
