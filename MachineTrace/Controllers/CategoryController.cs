using MachineTrace.Application.Commands.Category.Create;
using MachineTrace.Application.Queries.Category.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MachineTrace.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IMediator _mediator;
        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _mediator.Send(new GetAllQuery());
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCommand command)
        {
            if(!ModelState.IsValid)
            {
                return View(command);
            }
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }
    }
}
