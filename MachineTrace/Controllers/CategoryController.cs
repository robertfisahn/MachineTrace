using MachineTrace.Application.Commands.Category.Create;
using MachineTrace.Application.Commands.Category.Edit;
using MachineTrace.Application.Queries.Category.GetAll;
using MachineTrace.Application.Queries.Category.GetById;
using MachineTrace.Application.Queries.Category.GetByName;
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

        [Route("{id}/edit")]
        public async Task<IActionResult> Edit(int id)
        {
            var dto = await _mediator.Send(new GetByIdQuery(id));
            return View(dto);
        }

        [HttpPost]
        [Route("{id}/edit")]
        public async Task<IActionResult> Edit(string id, EditCommand command)
        {
            if(!ModelState.IsValid)
            {
                return View(command);
            }
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

        [Route("{name}/details")]
        public async Task<IActionResult> Details(string name)
        {
            var dto = await _mediator.Send(new GetByNameQuery(name));
            return View(dto);
        }
    }
}
