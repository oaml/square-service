using MediatR;
using SquareService.Domain;
using SquareService.Domain.ValueObjects;

namespace SquareService.Application.Commands;

public record AddPointInPointListCommand(int PointListId, Point Point) : IRequest
{
    public class Handler : IRequestHandler<AddPointInPointListCommand>
    {
        private readonly IPointListRepository _pointListRepository;

        public Handler(IPointListRepository pointListRepository)
        {
            _pointListRepository = pointListRepository;
        }

        public async Task Handle(AddPointInPointListCommand command, CancellationToken cancellationToken)
        {
            await _pointListRepository.AddPointToListAsync(command.PointListId, command.Point, cancellationToken);
        }
    }
}