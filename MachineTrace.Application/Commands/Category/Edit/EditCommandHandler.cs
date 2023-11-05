using AutoMapper;
using MachineTrace.Application.Dto.Category;
using MachineTrace.Domain.Intefaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineTrace.Application.Commands.Category.Edit
{
    public class EditCommandHandler : IRequestHandler<EditCommand>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public EditCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task Handle(EditCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id);
            _mapper.Map(request, category);
            await _categoryRepository.Save();
        }
    }
}
