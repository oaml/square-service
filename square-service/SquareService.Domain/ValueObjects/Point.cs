// ReSharper disable NonReadonlyMemberInGetHashCode

namespace SquareService.Domain.ValueObjects;

public class Point : ValueObject
{
    public Point()
    {
        
    }
    
    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }
    public int X { get;  set; }
    public int Y { get;  set; }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return X;
        yield return Y;
    }
}