using CA_Microservices_DotNet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA_Microservices_DotNet.Infrastructure.EntityConfigurations;

public class LogConfiguration : IEntityTypeConfiguration<Log>
{
    public void Configure(EntityTypeBuilder<Log> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Level)
                .IsRequired()
                .HasMaxLength(50);

        builder.Property(e => e.Message)
                .IsRequired(false);

        builder.Property(e => e.MessageTemplate)
                .IsRequired(false);

        builder.Property(e => e.TimeStamp)
                .IsRequired();

        builder.Property(e => e.Exception)
                .IsRequired(false);

        builder.Property(e => e.Properties)
                .IsRequired(false);
    }
}
