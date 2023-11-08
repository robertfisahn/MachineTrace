using AutoMapper;
using MachineTrace.Application.Commands.Category.Create;
using MachineTrace.Application.Commands.Category.Delete;
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
        private readonly IMapper _mapper;
        public CategoryController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
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
            var editCommand = _mapper.Map<EditCommand>(dto);
            return View(editCommand);
        }

        [HttpPost]
        [Route("{id}/edit")]
        public async Task<IActionResult> Edit(EditCommand command)
        {
            if(!ModelState.IsValid)
            {
                return View(command);
            }
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

        [Route("{id}/delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var dto = await _mediator.Send(new GetByIdQuery(id));
            var deleteCommand = _mapper.Map<DeleteCommand>(dto);
            return View(deleteCommand);
        }

        [HttpPost]
        [Route("{id}/delete")]
        public async Task<IActionResult> Delete(int id, DeleteCommand command)
        {
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
