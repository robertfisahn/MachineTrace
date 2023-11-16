using AutoMapper;
using MachineTrace.Application.Commands.Failure.Create;
using MachineTrace.Application.Commands.Failure.Delete;
using MachineTrace.Application.Commands.Failure.Edit;
using MachineTrace.Application.Queries.Failure.CreateForm;
using MachineTrace.Application.Queries.Failure.EditForm;
using MachineTrace.Application.Queries.Failure.GetAll;
using MachineTrace.Application.Queries.Failure.GetById;
using MachineTrace.Application.Queries.Failure.GetByMachine;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MachineTrace.Controllers
{
    public class FailureController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public FailureController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var failures = await _mediator.Send(new GetAllQuery());
            return View(failures);
        }

        [Route("machine/{machineId}/failures")]
        public async Task<IActionResult> GetByMachine(int machineId)
        {
            var failures = await _mediator.Send(new GetByMachineQuery(machineId));
            return View(failures);
        }
        [Route("machine/{machineId}/failure")]
        public async Task<IActionResult> Create(int machineId)
        {
            var failure = await _mediator.Send(new FailureCreateFormQuery(machineId));
            var createCommand = _mapper.Map<FailureCreateCommand>(failure);
            return View(createCommand);
        }

        [HttpPost]
        [Route("machine/{machineId}/failure")]
        public async Task<IActionResult> Create(FailureCreateCommand command)
        {
            if(!ModelState.IsValid)
            {
                return View(command);
            }
            await _mediator.Send(command);
            return RedirectToAction("Details", "Machine", new { id = command.MachineId });
        }

        [Route("failure/{id}/details")]
        [Route("machine/{machineId}/failure/{id}/details")]
        public async Task<IActionResult> Details(int id, int? machineId)
        {
            var failure = await _mediator.Send(new GetByIdQuery(id, machineId));
            return View(failure);
        }
        [Route("failure/{id}/edit")]
        public async Task<IActionResult> Edit(int id)
        {
            var failure = await _mediator.Send(new FailureEditFormQuery(id));
            var failureEditCommand = _mapper.Map<FailureEditCommand>(failure);
            return View(failureEditCommand);
        }

        [HttpPost]
        [Route("failure/{id}/edit")]
        public async Task<IActionResult> Edit(FailureEditCommand command)
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
