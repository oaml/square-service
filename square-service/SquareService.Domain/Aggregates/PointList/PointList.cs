using SquareService.Domain.ValueObjects;

namespace SquareService.Domain.Aggregates.PointList;

public class PointList
{
    public int PointListId { get; private set; }
    public List<Point> Points { get; private set; } = new();
}