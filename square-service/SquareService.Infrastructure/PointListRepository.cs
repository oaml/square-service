using Microsoft.EntityFrameworkCore;
using SquareService.Domain;
using SquareService.Domain.Aggregates.PointList;
using SquareService.Domain.ValueObjects;

namespace SquareService.Infrastructure;

public class PointListRepository : IPointListRepository
{
    private readonly PointListContext _context;

    public PointListRepository(PointListContext context)
    {
        _context = context;
    }

    public async Task<int> InsertNewPointListAsync(IReadOnlyCollection<Point> points, CancellationToken ctx)
    {
        var newPointList = new PointList(points);
        _context.PointLists.Add(newPointList);
        await _context.SaveChangesAsync(ctx);
        return newPointList.PointListId;
    }

    public async Task<PointList> GetPointListAsync(int pointListId, CancellationToken ctx)
    {
        var pointList = await _context.PointLists.FirstOrDefaultAsync(e => e.PointListId == pointListId, cancellationToken: ctx);
        if (pointList == null)
        {
            throw new KeyNotFoundException();
        }
        return pointList;
    }

    public async Task AddPointToListAsync(int pointListId, Point point, CancellationToken ctx)
    {
        var pointList = await GetPointListAsync(pointListId, ctx);
        pointList.AddPoint(point);
        await _context.SaveChangesAsync(ctx);
    }

    public async Task RemovePointFromListAsync(int pointListId, Point point, CancellationToken ctx)
    {
        var pointList = await GetPointListAsync(pointListId, ctx);
        pointList.RemovePoint(point);
        await _context.SaveChangesAsync(ctx);
    }
}