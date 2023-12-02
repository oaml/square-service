using SquareService.Domain.ValueObjects;

namespace SquareService.Domain;

public interface IPointListRepository
{
    public Task<int> InsertNewPointListAsync(IEnumerable<Point> points);
    public Task AddPointToList(int pointListId, Point point);
    public Task RemovePointFromList(int pointListId, Point point);
}