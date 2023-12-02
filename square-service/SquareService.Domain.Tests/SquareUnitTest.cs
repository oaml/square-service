using SquareService.Domain.ValueObjects;

namespace SquareService.Domain.Tests;

public class SquareUnitTest
{
    [Fact]
    public void Constructor_SortsPointsCorrectly()
    {
        var p1 = new Point(1, 1);
        var p2 = new Point(2, 2);
        var p3 = new Point(1, 2);
        var p4 = new Point(2, 1);

        var square = new Square(p1, p2, p3, p4);

        Assert.Equal(new Point(1, 1), square.P1);
        Assert.Equal(new Point(1, 2), square.P2);
        Assert.Equal(new Point(2, 1), square.P3);
        Assert.Equal(new Point(2, 2), square.P4);
    }

    [Fact]
    public void Equals_WithPointsInDifferentOrder_ReturnsTrue()
    {
        var square1 = new Square(new Point(1, 1), new Point(2, 2), new Point(1, 2), new Point(2, 1));
        var square2 = new Square(new Point(2, 1), new Point(1, 1), new Point(2, 2), new Point(1, 2));

        Assert.Equal(square1, square2);
    }

    [Fact]
    public void Equals_WithDifferentPoints_ReturnsFalse()
    {
        var square1 = new Square(new Point(1, 1), new Point(2, 2), new Point(1, 2), new Point(2, 1));
        var square2 = new Square(new Point(3, 3), new Point(4, 4), new Point(3, 4), new Point(4, 3));

        Assert.NotEqual(square1, square2);
    }

    [Fact]
    public void GetHashCode_EqualSquares_ReturnSameHashCode()
    {
        var square1 = new Square(new Point(1, 1), new Point(2, 2), new Point(1, 2), new Point(2, 1));
        var square2 = new Square(new Point(2, 1), new Point(1, 1), new Point(2, 2), new Point(1, 2));

        Assert.Equal(square1.GetHashCode(), square2.GetHashCode());
    }
}
