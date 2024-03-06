using CA_Microservices_DotNet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA_Microservices_DotNet.Infrastructure.EntityConfigurations;

internal class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("AppUsers");

        builder
            .Property(u => u.FirstName)
            .HasDefaultValue("");

        builder
            .Property(u => u.LastName)
            .HasDefaultValue("");

        builder
            .Property(u => u.SecondLastName)
            .HasDefaultValue("");

        builder
            .Property(u => u.Phone)
            .HasDefaultValue("");
    }
}
