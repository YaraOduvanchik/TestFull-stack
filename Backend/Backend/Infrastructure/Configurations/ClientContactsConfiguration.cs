using Backend.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infrastructure.Configurations;

public class ClientContactsConfiguration : IEntityTypeConfiguration<ClientContacts>
{
    public void Configure(EntityTypeBuilder<ClientContacts> builder)
    {
        builder.ToTable("client_contacts");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.ClientId).IsRequired();

        builder.Property(c => c.ContactType)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(c => c.ContactValue)
            .IsRequired()
            .HasMaxLength(255);

        builder.HasOne<Client>()
            .WithMany()
            .HasForeignKey(c => c.ClientId);
    }
}