using AutoMapper;
using MachineTrace.Application.Commands.Category.Edit;
using MachineTrace.Application.Dto.Category;
using MachineTrace.Domain.Intefaces;
using MediatR;

namespace MachineTrace.Application.Queries.Category.GetById
{
    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, CategoryDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetByIdQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryDto> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id);
            var dto = _mapper.Map<CategoryDto>(category);
            return dto;
        }
    }
}
