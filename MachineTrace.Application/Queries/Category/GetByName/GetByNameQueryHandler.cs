using AutoMapper;
using MachineTrace.Application.Dto.Category;
using MachineTrace.Domain.Intefaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineTrace.Application.Queries.Category.GetByName
{
    public class GetByNameQueryHandler : IRequestHandler<GetByNameQuery, CategoryDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetByNameQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;

        }
        public async Task<CategoryDto> Handle(GetByNameQuery request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByName(request.Name);
            var dto = _mapper.Map<CategoryDto>(category);

            return dto;
        }
    }
}
