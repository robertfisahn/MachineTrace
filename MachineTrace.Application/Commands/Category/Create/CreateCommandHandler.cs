using AutoMapper;
using MachineTrace.Domain.Intefaces;
using MediatR;

namespace MachineTrace.Application.Commands.Category.Create
{
    public class CreateCommandHandler : IRequestHandler<CreateCommand>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CreateCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Domain.Entities.Category>(request);
            await _categoryRepository.Create(category);
        }
    }
}
