using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SquareService.Domain.Aggregates.PointList;

namespace SquareService.Infrastructure.Configurations;

public class PointListConfiguration : IEntityTypeConfiguration<PointList>
{
    public void Configure(EntityTypeBuilder<PointList> builder)
    {
        builder.HasKey(e => e.PointListId);
        builder.OwnsMany(e => e.Points);
    }
}