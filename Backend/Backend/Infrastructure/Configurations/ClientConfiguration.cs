using Backend.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infrastructure.Configurations;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.ToTable("client");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.ClientName)
            .HasMaxLength(200)
            .IsRequired();
    }
}