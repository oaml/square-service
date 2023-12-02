using SquareService.Domain.Aggregates.PointList;
using SquareService.Domain.ValueObjects;

namespace SquareService.Domain.DomainServices.SquaringService;

public interface ISquaringService
{
    public Task<IEnumerable<Square>> GetSquaresFromPointList(PointList pointList);
}