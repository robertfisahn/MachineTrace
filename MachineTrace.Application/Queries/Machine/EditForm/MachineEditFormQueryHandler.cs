using AutoMapper;
using MachineTrace.Application.Dto.Category;
using MachineTrace.Application.Dto.Machine;
using MachineTrace.Domain.Enums;
using MachineTrace.Domain.Intefaces;
using MediatR;
    namespace MachineTrace.Application.Queries.Machine.EditForm
    {
        public class MachineEditFormQueryHandler : IRequestHandler<MachineEditFormQuery, MachineDtoEdit>
        {
            private readonly ICategoryRepository _categoryRepository;
            private readonly IMapper _mapper;
            private readonly IMachineRepository _machineRepository;

            public MachineEditFormQueryHandler(ICategoryRepository categoryRepository, IMapper mapper, IMachineRepository machineRepository)
            {
                _categoryRepository = categoryRepository;
                _mapper = mapper;
                _machineRepository = machineRepository;
            }
            public async Task<MachineDtoEdit> Handle(MachineEditFormQuery request, CancellationToken cancellationToken)
            {   
                var machine = await _machineRepository.GetByIdAsync(request.Id);
                var editForm = _mapper.Map<MachineDtoEdit>(machine);
                editForm.AvailableConditions = Enum.GetNames(typeof(MachineCondition));
                editForm.AvailableStatuses = Enum.GetNames(typeof(MachineStatus));
                
                var categories = await _categoryRepository.GetAll();
                var dtos = _mapper.Map<IEnumerable<CategoryDto>>(categories);
                editForm.Categories = dtos;
                return editForm;
            }
        }
    }
