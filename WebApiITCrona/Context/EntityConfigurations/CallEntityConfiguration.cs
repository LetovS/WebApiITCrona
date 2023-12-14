using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApiITCrona.Context.Entity;

namespace WebApiITCrona.Context.EntityConfigurations;

/// <summary>
/// Настройка сущности
/// </summary>
public class CallEntityConfiguration : IEntityTypeConfiguration<CallEntity>
{
    /// <summary>
    /// ctor.
    /// </summary>
    public void Configure(EntityTypeBuilder<CallEntity> builder)
    {
        builder.ToTable("Calls");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.Property(x => x.IpAddress).IsRequired();

        builder.HasIndex(x => x.IpAddress).IsUnique().HasDatabaseName("UQ_Calls_IpAddress");
    }
}