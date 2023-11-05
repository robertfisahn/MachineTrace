using FluentValidation;
using MachineTrace.Domain.Intefaces;

namespace MachineTrace.Application.Commands.Category.Create;

public class CreateCommandValidator : AbstractValidator<CreateCommand>
{
    public CreateCommandValidator(ICategoryRepository repository)
    {
        RuleFor(c => c.Name)
            .NotEmpty()
            .MaximumLength(25).WithMessage("Name is too long. Maximum numbers of characters is 25.")
            .Custom((value, context) =>
            {
                var existingName = repository.GetByName(value);
                if (existingName != null)
                {
                    context.AddFailure($"{value} already exist");
                }
            });
    }
}
