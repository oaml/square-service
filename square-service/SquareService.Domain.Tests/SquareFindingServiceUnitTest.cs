using SquareService.Domain.Aggregates.PointList;
using SquareService.Domain.DomainServices.SquaringService;
using SquareService.Domain.ValueObjects;
namespace SquareService.Domain.Tests;

public class SquareFindingServiceUnitTest
{
    [Fact]
    public async Task WithNoPoints_ReturnsEmpty()
    {
        var service = new SquareFindingService();
        var pointList = new PointList();

        var result = await service.GetSquaresFromPointList(pointList);

        Assert.Empty(result);
    }

    [Fact]
    public async Task WithNonSquarePoints_ReturnsEmpty()
    {
        var service = new SquareFindingService();
        var pointList = new PointList(new List<Point> { new Point(1, 1), new Point(2, 2), new Point(100, 100), new Point(101, 101) });

        var result = await service.GetSquaresFromPointList(pointList);

        Assert.Empty(result);
    }

    [Fact]
    public async Task WithPointsFormingSingleSquare_ReturnsOneSquare()
    {
        var service = new SquareFindingService();
        var pointList = new PointList(new List<Point>
        {
            new Point(0, 0), new Point(0, 1),
            new Point(1, 0), new Point(1, 1)
        });

        var result = await service.GetSquaresFromPointList(pointList);

        Assert.Single(result);
    }

    
    [Fact]
    public async Task WithPointsFormingTwoSquares_ReturnsTwoSquares()
    {
        var service = new SquareFindingService();
        var pointList = new PointList(new List<Point>
        {
            new Point(0, 0), new Point(0, 1),
            new Point(1, 0), new Point(1, 1),
            new Point(-100, 100),  new Point(-100, -100), 
            new Point(100, 100),  new Point(100, -100), 
        });

        var result = await service.GetSquaresFromPointList(pointList);

        Assert.Equal(2, result.Count());
    }
    
    [Fact]
    public async Task WithPointsCausingOverflow_ReturnsNoValidSquare()
    {
        var service = new SquareFindingService();
        var pointList = new PointList(new List<Point>
        {
            new Point(int.MinValue, int.MinValue), new Point(-1, -1), new Point(1, -1), new Point(-2147483648, 2147483646)
        });

        var result = await service.GetSquaresFromPointList(pointList);

        Assert.Empty(result);
    }
}