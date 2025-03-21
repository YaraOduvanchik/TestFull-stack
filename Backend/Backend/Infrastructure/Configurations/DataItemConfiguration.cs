using Backend.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infrastructure.Configurations;

public class DataItemConfiguration : IEntityTypeConfiguration<DataItem>
{
    public void Configure(EntityTypeBuilder<DataItem> builder)
    {
        builder.ToTable("data_item");
        
        builder.HasKey(d => d.Id);
        
        builder.Property(d => d.Code).IsRequired();

        builder.Property(d => d.Value).IsRequired();
    }
}

