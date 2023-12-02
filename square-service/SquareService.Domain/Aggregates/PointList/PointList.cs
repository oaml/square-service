using SquareService.Domain.DomainExceptions;
using SquareService.Domain.ValueObjects;

namespace SquareService.Domain.Aggregates.PointList;

public class PointList
{
    public PointList()
    {
    }

    public PointList(IReadOnlyCollection<Point> points)
    {
        if (points.Distinct().Count() != points.Count)
        {
            throw new DuplicatePointException();
        }
        Points.AddRange(points);
    }
    public int PointListId { get; private set; }
    public List<Point> Points { get; private set; } = new();

    public void AddPoint(Point point)
    {
        if (Points.Any(e => e.Equals(point)))
        {
            throw new DuplicatePointException();
        }
        Points.Add(point);
    }

    public void RemovePoint(Point point)
    {
        var existingPoint = Points.FirstOrDefault(e => e.Equals(point));
        if (existingPoint == null)
        {
            throw new PointNotFoundException();
        }
        Points.Remove(point);
    }
}