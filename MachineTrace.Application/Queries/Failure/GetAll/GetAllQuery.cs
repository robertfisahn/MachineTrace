using MachineTrace.Application.Dto.Failure;
using MediatR;

namespace MachineTrace.Application.Queries.Failure.GetAll
{
    public class GetAllQuery : IRequest<IEnumerable<FailureDto>>
    {
    }
}
