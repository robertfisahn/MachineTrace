using AutoMapper;
using MachineTrace.Application.Dto.Category;
using MachineTrace.Domain.Intefaces;
using MediatR;

namespace MachineTrace.Application.Queries.Category.GetAll
{
    public class GetAllQueryHandler : IRequestHandler<GetAllQuery, IEnumerable<CategoryDto>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetAllQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CategoryDto>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetAll();
            var dtos = _mapper.Map<IEnumerable<CategoryDto>>(categories);
            return dtos;
        }
    }
}
