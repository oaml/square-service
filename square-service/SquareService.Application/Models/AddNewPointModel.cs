using SquareService.Domain.ValueObjects;

namespace SquareService.Application.Models;

public record PointModel(int X, int Y)
{
    public Point ToDomainObject()
    {
        return new Point(X, Y);
    }
}
public record AddNewPointModel(PointModel Point);