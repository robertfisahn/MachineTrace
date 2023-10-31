using FluentValidation;
using MachineTrace.Application.Dto.Category;
using MachineTrace.Domain.Intefaces;

namespace MachineTrace.Application.Validators
{
    public class CategoryUpsertDtoValidator : AbstractValidator<CategoryDto>
    {
        public CategoryUpsertDtoValidator(ICategoryRepository repository)
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .MaximumLength(25).WithMessage("Name is too long. Maximum numbers of characters is 25.")
                .Custom((value, context) =>
                {
                    var existingName = repository.GetByName(value).Result;
                    if(existingName != null)
                    {
                        context.AddFailure($"{value} already exist");
                    }
                });
        }
    }
}
