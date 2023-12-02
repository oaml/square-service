using MediatR;
using SquareService.Domain;
using SquareService.Domain.DomainServices.SquaringService;
using SquareService.Domain.ValueObjects;

namespace SquareService.Application.Queries;

public record GetSquaresFromPointListQuery(int PointListId) : IRequest<IEnumerable<Square>>
{
    public class Handler : IRequestHandler<GetSquaresFromPointListQuery, IEnumerable<Square>>
    {
        private readonly IPointListRepository _pointListRepository;
        private readonly ISquareFindingService _squareFindingService;

        public Handler(IPointListRepository pointListRepository, ISquareFindingService squareFindingService)
        {
            _pointListRepository = pointListRepository;
            _squareFindingService = squareFindingService;
        }

        public async Task<IEnumerable<Square>> Handle(GetSquaresFromPointListQuery query, CancellationToken cancellationToken)
        {
            var pointList = await _pointListRepository.GetPointListAsync(query.PointListId, cancellationToken);
            return await _squareFindingService.GetSquaresFromPointList(pointList);
        }
    }
}