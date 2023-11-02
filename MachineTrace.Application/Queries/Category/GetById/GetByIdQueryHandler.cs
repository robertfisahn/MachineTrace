using AutoMapper;
using MachineTrace.Application.Commands.Category.Edit;
using MachineTrace.Application.Dto.Category;
using MachineTrace.Domain.Intefaces;
using MediatR;

namespace MachineTrace.Application.Queries.Category.GetById
{
    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, EditCommand>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetByIdQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<EditCommand> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetById(request.Id);
            var editCommand = _mapper.Map<EditCommand>(category);
            return editCommand;
        }
    }
}
