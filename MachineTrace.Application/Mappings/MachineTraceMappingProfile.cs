using AutoMapper;
using MachineTrace.Application.Commands.Category.Delete;
using MachineTrace.Application.Commands.Category.Edit;
using MachineTrace.Application.Commands.Machine.Create;
using MachineTrace.Application.Commands.Machine.Delete;
using MachineTrace.Application.Commands.Machine.Edit;
using MachineTrace.Application.Dto.Category;
using MachineTrace.Application.Dto.Machine;

namespace MachineTrace.Application.Mappings
{
    public class MachineTraceMappingProfile : Profile
    {
        public MachineTraceMappingProfile()
        {
            CreateMap<CategoryDto, Domain.Entities.Category>();
            CreateMap<Domain.Entities.Category, CategoryDto>();
            CreateMap<CategoryDto, Commands.Category.Edit.EditCommand>();
            CreateMap<CategoryDto, DeleteCommand>();

            CreateMap<MachineDto, Domain.Entities.Machine>();
            CreateMap<Domain.Entities.Machine, MachineDto>()
                .ForMember(c => c.Status, opt => opt.MapFrom(src => src.Status.ToString()))
                .ForMember(c => c.Condition, opt => opt.MapFrom(src => src.Condition.ToString()))
                .ForMember(c => c.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
            CreateMap<MachineDtoCreate, CreateCommand>();
            CreateMap<CreateCommand, MachineDtoCreate>();
            CreateMap<CreateCommand, Domain.Entities.Machine>();
            CreateMap<Domain.Entities.Machine, MachineDtoEdit>();
            CreateMap<MachineEditCommand, Domain.Entities.Machine>();
            CreateMap<MachineDtoEdit, MachineEditCommand>();
            CreateMap<MachineEditCommand, MachineDtoEdit>();
            CreateMap<MachineDto, MachineDeleteCommand>();
        }
    }
}
