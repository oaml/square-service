using SquareService.Domain.Aggregates.PointList;
using SquareService.Domain.ValueObjects;

namespace SquareService.Domain;

public interface IPointListRepository
{
    public Task<int> InsertNewPointListAsync(IEnumerable<Point> points, CancellationToken ctx = default);
    public Task<PointList> GetPointListAsync(int pointListId, CancellationToken ctx = default);
    public Task AddPointToListAsync(int pointListId, Point point, CancellationToken ctx = default);
    public Task RemovePointFromListAsync(int pointListId, Point point, CancellationToken ctx = default);
}