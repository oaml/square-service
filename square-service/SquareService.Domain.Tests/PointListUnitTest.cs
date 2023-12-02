using SquareService.Domain.Aggregates.PointList;
using SquareService.Domain.DomainExceptions;
using SquareService.Domain.ValueObjects;

namespace SquareService.Domain.Tests;

public class PointListUnitTest
{
    [Fact]
    public void Constructor_WithUniquePoints_InitializesCorrectly()
    {
        var points = new List<Point> { new Point(1, 1), new Point(2, 2) };
        var pointList = new PointList(points);

        Assert.Equal(points.Count, pointList.Points.Count);
        Assert.True(pointList.Points.SequenceEqual(points));
    }

    [Fact]
    public void Constructor_WithDuplicatePoints_ThrowsDuplicatePointException()
    {
        var points = new List<Point> { new Point(1, 1), new Point(1, 1) };

        Assert.Throws<DuplicatePointException>(() => new PointList(points));
    }

    [Fact]
    public void AddPoint_WithNewPoint_AddsPoint()
    {
        var pointList = new PointList();
        var point = new Point(1, 1);

        pointList.AddPoint(point);

        Assert.Contains(point, pointList.Points);
    }

    [Fact]
    public void AddPoint_WithDuplicatePoint_ThrowsDuplicatePointException()
    {
        var point = new Point(1, 1);
        var pointList = new PointList(new List<Point> { point });

        Assert.Throws<DuplicatePointException>(() => pointList.AddPoint(point));
    }

    [Fact]
    public void RemovePoint_WithExistingPoint_RemovesPoint()
    {
        var point = new Point(1, 1);
        var pointList = new PointList(new List<Point> { point });

        pointList.RemovePoint(point);

        Assert.DoesNotContain(point, pointList.Points);
    }

    [Fact]
    public void RemovePoint_WithNonExistingPoint_ThrowsPointNotFoundException()
    {
        var pointList = new PointList();
        var point = new Point(1, 1);

        Assert.Throws<PointNotFoundException>(() => pointList.RemovePoint(point));
    }
}