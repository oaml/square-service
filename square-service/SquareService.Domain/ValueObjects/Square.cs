namespace SquareService.Domain.ValueObjects;

public class Square : ValueObject
{
    public Square(Point p1, Point p2, Point p3, Point p4)
    {
        Points = new [] { p1, p2, p3, p4 };
        Array.Sort(Points, (a, b) => a.X == b.X ? a.Y.CompareTo(b.Y) : a.X.CompareTo(b.X));
    }
    public Point[] Points { get; private set; }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Points[0];
        yield return Points[1];
        yield return Points[2];
        yield return Points[3];
    }
}