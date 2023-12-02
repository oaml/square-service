namespace SquareService.Domain.ValueObjects;

public class Square : ValueObject
{
    public Square(Point p1, Point p2, Point p3, Point p4)
    {
        // Sort the points so that squares like (p1, p2, p3, p4) are considered equal to (p4, p3, p2, p1)
        var points = new [] { p1, p2, p3, p4 };
        Array.Sort(points, (a, b) => a.X == b.X ? a.Y.CompareTo(b.Y) : a.X.CompareTo(b.X));
        P1 = points[0];
        P2 = points[1];
        P3 = points[2];
        P4 = points[3];
    }
    public Point P1 { get; private set; }
    public Point P2 { get; private set; }
    public Point P3 { get; private set; }
    public Point P4 { get; private set; }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return P1;
        yield return P2;
        yield return P3;
        yield return P4;
    }
}