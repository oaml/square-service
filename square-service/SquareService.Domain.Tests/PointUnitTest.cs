using SquareService.Domain.ValueObjects;

namespace SquareService.Domain.Tests;

public class PointUnitTest
{
    [Fact]
    public void Constructor_InitializesCorrectValues()
    {
        var point = new Point(1, 2);

        Assert.Equal(1, point.X);
        Assert.Equal(2, point.Y);
    }

    [Fact]
    public void Equals_WithSameValues_ReturnsTrue()
    {
        var point1 = new Point(1, 2);
        var point2 = new Point(1, 2);

        Assert.Equal(point1, point2);
    }

    [Fact]
    public void Equals_WithDifferentValues_ReturnsFalse()
    {
        var point1 = new Point(1, 2);
        var point2 = new Point(3, 4);

        Assert.NotEqual(point1, point2);
    }

    [Fact]
    public void GetHashCode_EqualPoints_ReturnSameHashCode()
    {
        var point1 = new Point(1, 2);
        var point2 = new Point(1, 2);

        Assert.Equal(point1.GetHashCode(), point2.GetHashCode());
    }
}