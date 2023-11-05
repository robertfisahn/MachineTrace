using FluentValidation;
using MachineTrace.Domain.Intefaces;

namespace MachineTrace.Application.Commands.Category.Edit
{
    public class EditCommandValidator : AbstractValidator<EditCommand>
    {
        public EditCommandValidator(ICategoryRepository repository)
        {
            RuleFor(c => c.Name)
            .NotEmpty()
            .MaximumLength(25).WithMessage("Name is too long. Maximum numbers of characters is 25.")
            .Must((command, cancellation) =>
            {
                var category = repository.GetById(command.Id);
                return category == null || category.Name != command.Name;
            }).WithMessage("The new name must be different from the current name.")
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
}
