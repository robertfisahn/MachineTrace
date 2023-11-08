using MachineTrace.Domain.Intefaces;
using MediatR;

namespace MachineTrace.Application.Commands.Category.Delete
{
    public class DeleteCommandHandler : IRequestHandler<DeleteCommand>
    {
        private readonly ICategoryRepository _categoryRepository;

        public DeleteCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task Handle(DeleteCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id);
            await _categoryRepository.Delete(category);
        }
    }
}
