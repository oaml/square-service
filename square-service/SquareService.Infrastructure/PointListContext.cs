using Microsoft.EntityFrameworkCore;
using SquareService.Domain.Aggregates.PointList;

namespace SquareService.Infrastructure;

public class PointListContext  : DbContext
{
    public PointListContext(DbContextOptions<PointListContext> options) : base(options)
    {

    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PointListContext).Assembly);
    }

    public DbSet<PointList> PointLists { get; set; } = default!;
}