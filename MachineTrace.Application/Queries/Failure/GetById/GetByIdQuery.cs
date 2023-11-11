using MachineTrace.Application.Dto.Failure;
using MediatR;

namespace MachineTrace.Application.Queries.Failure.GetById
{
    public class GetByIdQuery : IRequest<FailureDtoDetails>
    {
        public int Id { get; set; }
        public int? FromMachine { get; set; }

        public GetByIdQuery(int id, int? fromMachine)
        {
            Id = id;
            FromMachine = fromMachine;
        }

        public GetByIdQuery(int id)
        {
            Id = id;
        }
    }
}
