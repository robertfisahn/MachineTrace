using MachineTrace.Application.Commands.Category.Edit;
using MediatR;


namespace MachineTrace.Application.Queries.Category.GetById
{
    public class GetByIdQuery : IRequest<EditCommand>
    {
        public int Id { get; set; }

        public GetByIdQuery(int id)
        {
            Id = id;
        }
    }
}
