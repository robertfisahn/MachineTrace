using AutoMapper;
using MachineTrace.Application.Commands.Category.Delete;
using MachineTrace.Application.Commands.Failure.Create;
using MachineTrace.Application.Commands.Failure.Delete;
using MachineTrace.Application.Commands.Failure.Edit;
using MachineTrace.Application.Commands.Machine.Create;
using MachineTrace.Application.Commands.Machine.Delete;
using MachineTrace.Application.Commands.Machine.Edit;
using MachineTrace.Application.Dto.Category;
using MachineTrace.Application.Dto.Failure;
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
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
                .ForMember(dest => dest.Condition, opt => opt.MapFrom(src => src.Condition.ToString()))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
            CreateMap<MachineDtoCreate, CreateCommand>();
            CreateMap<CreateCommand, MachineDtoCreate>();
            CreateMap<CreateCommand, Domain.Entities.Machine>();
            CreateMap<Domain.Entities.Machine, MachineDtoEdit>();
            CreateMap<MachineEditCommand, Domain.Entities.Machine>();
            CreateMap<MachineDtoEdit, MachineEditCommand>();
            CreateMap<MachineEditCommand, MachineDtoEdit>();
            CreateMap<MachineDto, MachineDeleteCommand>();
            CreateMap<Domain.Entities.Machine, MachineDtoShort>();

            CreateMap<Domain.Entities.Failure, FailureDto>()
                .ForMember(dest => dest.MachineCode, opt => opt.MapFrom(src => src.Machine.Code));
            CreateMap<FailureDtoCreate, FailureCreateCommand>();
            CreateMap<FailureCreateCommand, Domain.Entities.Failure>();
            CreateMap<Domain.Entities.Failure, FailureDtoDetails>();
            CreateMap<FailureEditCommand, Domain.Entities.Failure>();
            CreateMap<FailureEditCommand, FailureDtoEdit>();
            CreateMap<Domain.Entities.Failure, FailureDtoEdit>();
            CreateMap<FailureDtoEdit, FailureEditCommand>();
            CreateMap<FailureDtoDetails, FailureDeleteCommand>();
        }
    }
}
