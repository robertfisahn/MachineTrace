using AutoMapper;
using MachineTrace.Application.Dto.Category;
using MachineTrace.Application.Dto.Machine;
using MachineTrace.Domain.Enums;
using MachineTrace.Domain.Intefaces;
using MediatR;
namespace MachineTrace.Application.Queries.Machine.CreateForm
{
    public class MachineCreateFormQueryHandler : IRequestHandler<MachineCreateFormQuery, MachineDtoCreate>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;


        public MachineCreateFormQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<MachineDtoCreate> Handle(MachineCreateFormQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetAll();
            var dtos = _mapper.Map<IEnumerable<CategoryDto>>(categories);
            var conditions = Enum.GetNames(typeof(MachineCondition));
            var statuses = Enum.GetNames(typeof(MachineStatus));
            var form = new MachineDtoCreate
            {
                Categories = dtos,
                AvailableConditions = conditions,
                AvailableStatuses = statuses
            };

            return form;
        }
    }
}
