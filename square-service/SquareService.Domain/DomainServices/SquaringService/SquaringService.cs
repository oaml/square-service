using SquareService.Domain.Aggregates.PointList;
using SquareService.Domain.ValueObjects;

namespace SquareService.Domain.DomainServices.SquaringService;

public class SquaringService : ISquaringService
{
    public Task<IEnumerable<Square>> GetSquaresFromPointList(PointList pointList)
    {
        throw new NotImplementedException();
    }
}