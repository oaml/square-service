using MediatR;
using SquareService.Application.Queries;
using SquareService.Domain;
using SquareService.Domain.Aggregates.PointList;
using SquareService.Domain.ValueObjects;

namespace SquareService.Application.Commands;

public record CreatePointListCommand(IEnumerable<Point> Points) : IRequest<int>
{
    public class Handler : IRequestHandler<CreatePointListCommand, int>
    {
        private readonly IPointListRepository _pointListRepository;

        public Handler(IPointListRepository pointListRepository)
        {
            _pointListRepository = pointListRepository;
        }

        public async Task<int> Handle(CreatePointListCommand command, CancellationToken cancellationToken)
        {
            return await _pointListRepository.InsertNewPointListAsync(command.Points, cancellationToken);
        }
    }
}