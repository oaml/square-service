using SquareService.Domain.Aggregates.PointList;
using SquareService.Domain.ValueObjects;

namespace SquareService.Domain.DomainServices.SquaringService;

public class SquareFindingService : ISquareFindingService
{
    public Task<IEnumerable<Square>> GetSquaresFromPointList(PointList pointList)
    {
        var pointSet = new HashSet<Point>(pointList.Points);
        var squareSet = new HashSet<Square>();
        foreach (var uniquePointPair in GetAllUniquePairs(pointSet))
        {
            var leftPoints = GetPotentialSquarePointsToTheLeft(uniquePointPair.p1, uniquePointPair.p2);
            if (leftPoints.isValid && pointSet.Contains(leftPoints.l1) && pointSet.Contains(leftPoints.l2))
            {
                squareSet.Add(new Square(uniquePointPair.p1, uniquePointPair.p2, leftPoints.l1, leftPoints.l2));
            }
            var rightPoints = GetPotentialSquarePointsToTheRight(uniquePointPair.p1, uniquePointPair.p2);
            if (rightPoints.isValid && pointSet.Contains(rightPoints.r1) && pointSet.Contains(rightPoints.r2))
            {
                squareSet.Add(new Square(uniquePointPair.p1, uniquePointPair.p2, rightPoints.r1, rightPoints.r2));
            }
        }

        return Task.FromResult(squareSet.AsEnumerable());
    }
    
    private static IEnumerable<(Point p1, Point p2)> GetAllUniquePairs(HashSet<Point> points)
    {
        var visited = new HashSet<Point>();
        foreach (var point1 in points)
        {
            visited.Add(point1);
            foreach (var point2 in points)
            {
                if (!visited.Contains(point2))
                {
                    yield return (point1, point2);
                }
            }
        }
    }
    
    // Given any two points (p1, p2) there are only two squares that can exist which include them. Two perpendicular points to the left (l1, l2) and two perpendicular points to the right (r1, r2)
    // Illustration:
    // l1 - - - - p1 - - - - r1
    //            |    
    //            | 
    //            |
    // l2 - - - - p2 - - - - r2
    private static (Point l1, Point l2, bool isValid) GetPotentialSquarePointsToTheLeft(Point p1, Point p2)
    {
        // Calculate the differences in x and y coordinates
        var dx = p2.X - p1.X; 
        var dy = p2.Y - p1.Y; 
        try
        {
            checked
            {
                var l1 = new Point(p1.X - dy, p1.Y + dx);
                var l2 = new Point(p2.X - dy, p2.Y + dx);
                return (l1, l2, true);
            }
        }
        // if at least one operation overflowed then it means at least one point goes out of bounds and this pair is not valid
        catch (OverflowException)
        {
            return (new Point(), new Point(), false);
        }
    }
    
    private static (Point r1, Point r2, bool isValid) GetPotentialSquarePointsToTheRight(Point p1, Point p2)
    {
        var dx = p2.X - p1.X; 
        var dy = p2.Y - p1.Y;
        try
        {
            checked
            {
                var r1 = new Point(p1.X + dy, p1.Y -dx); 
                var r2 = new Point(p2.X + dy, p2.Y -dx);
                return (r1, r2, true);
            }
        }
        catch (OverflowException)
        {
            return (new Point(), new Point(), false);
        }
    }
    



}