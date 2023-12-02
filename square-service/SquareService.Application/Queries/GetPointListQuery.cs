using MediatR;
using SquareService.Domain;
using SquareService.Domain.Aggregates.PointList;

namespace SquareService.Application.Queries;

public record GetPointListQuery(int PointListId) : IRequest<PointList?>
{
    public class Handler : IRequestHandler<GetPointListQuery, PointList?>
    {
        private readonly IPointListRepository _pointListRepository;

        public Handler(IPointListRepository pointListRepository)
        {
            _pointListRepository = pointListRepository;
        }

        public async Task<PointList?> Handle(GetPointListQuery query, CancellationToken cancellationToken)
        {
            return await _pointListRepository.GetPointListAsync(query.PointListId, cancellationToken);
        }
    }
}