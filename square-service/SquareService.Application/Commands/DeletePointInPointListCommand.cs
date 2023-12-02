using MediatR;
using SquareService.Domain;
using SquareService.Domain.ValueObjects;

namespace SquareService.Application.Commands;

public record DeletePointInPointListCommand(int PointListId, Point Point) : IRequest
{
    public class Handler : IRequestHandler<DeletePointInPointListCommand>
    {
        private readonly IPointListRepository _pointListRepository;

        public Handler(IPointListRepository pointListRepository)
        {
            _pointListRepository = pointListRepository;
        }

        public async Task Handle(DeletePointInPointListCommand command, CancellationToken cancellationToken)
        {
            await _pointListRepository.RemovePointFromListAsync(command.PointListId, command.Point, cancellationToken);
        }
    }
}