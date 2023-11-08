using AutoMapper;
using MachineTrace.Application.Commands.Machine.Create;
using MachineTrace.Application.Commands.Machine.Delete;
using MachineTrace.Application.Commands.Machine.Edit;
using MachineTrace.Application.Queries.Machine.CreateForm;
using MachineTrace.Application.Queries.Machine.EditForm;
using MachineTrace.Application.Queries.Machine.GetAll;
using MachineTrace.Application.Queries.Machine.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MachineTrace.Controllers
{
    public class MachineController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public MachineController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var machines = await _mediator.Send(new GetAllQuery());
            return View(machines);
        }

        [Route("machine/{id}/details")]
        public async Task<IActionResult> Details(int id)
        {
            var machine = await _mediator.Send(new GetByIdQuery(id));
            return View(machine);
        }

        public async Task<IActionResult> Create()
        {
            var machine = await _mediator.Send(new MachineCreateFormQuery());
            var createCommand = _mapper.Map<CreateCommand>(machine);
            return View(createCommand);
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
        [Route("machine/{id}/edit")]
        public async Task<IActionResult> Edit(int id)
        {
            var machine = await _mediator.Send(new MachineEditFormQuery(id));
            var editCommand = _mapper.Map<MachineEditCommand>(machine);
            return View(editCommand);
        }
        [HttpPost]
        [Route("machine/{id}/edit")]
        public async Task<IActionResult> Edit(MachineEditCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

        [Route("machine/{id}/delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var machine = await _mediator.Send(new GetByIdQuery(id));
            var form = _mapper.Map<MachineDeleteCommand>(machine);
            return View(form);
        }
        [HttpPost]
        [Route("machine/{id}/delete")]
        public async Task<IActionResult> Delete(MachineDeleteCommand command)
        {
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

    }
}
