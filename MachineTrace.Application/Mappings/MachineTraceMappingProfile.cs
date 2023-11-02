using AutoMapper;
using MachineTrace.Application.Commands.Category.Edit;
using MachineTrace.Application.Dto.Category;
namespace MachineTrace.Application.Mappings
{
    public class MachineTraceMappingProfile : Profile
    {
        public MachineTraceMappingProfile()
        {
            CreateMap<CategoryDto, Domain.Entities.Category>();
            CreateMap<Domain.Entities.Category, CategoryDto>();
            CreateMap<CategoryDto, EditCommand>();
            CreateMap<EditCommand, Domain.Entities.Category>();
            CreateMap<Domain.Entities.Category, EditCommand>();
        }
    }
}
