using Backend.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infrastructure.Configurations;

public class DateIntervalConfiguration : IEntityTypeConfiguration<DateInterval>
{
    public void Configure(EntityTypeBuilder<DateInterval> builder)
    {
        builder.ToTable("dates");

        builder.HasKey(d => new { d.Id, d.Dt });

        builder.Property(d => d.Id)
            .HasColumnName("id");

        builder.Property(d => d.Dt)
            .HasColumnName("dt")
            .IsRequired();
    }
}