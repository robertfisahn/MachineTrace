using MachineTrace.Application.Dto.Failure;
using MediatR;

namespace MachineTrace.Application.Queries.Failure.EditForm
{
    public class FailureEditFormQuery : IRequest<FailureDtoEdit>
    {
        public int Id { get; set; }

        public FailureEditFormQuery(int id)
        {
            Id = id;
        }
    }
}
