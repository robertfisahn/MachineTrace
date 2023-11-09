using AutoMapper;
using MachineTrace.Application.Commands.Failure.Create;
using MachineTrace.Application.Commands.Failure.Delete;
using MachineTrace.Application.Commands.Failure.Edit;
using MachineTrace.Application.Queries.Failure.CreateForm;
using MachineTrace.Application.Queries.Failure.EditForm;
using MachineTrace.Application.Queries.Failure.GetAll;
using MachineTrace.Application.Queries.Failure.GetById;
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

        public async Task<IActionResult> Create()
        {
            var failure = await _mediator.Send(new FailureCreateFormQuery());
            var createCommand = _mapper.Map<FailureCreateCommand>(failure);
            return View(createCommand);
        }

        [HttpPost]
        public async Task<IActionResult> Create(FailureCreateCommand command)
        {
            if(!ModelState.IsValid)
            {
                return View(command);
            }
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

        [Route("failure/{id}/details")]
        public async Task<IActionResult> Details(int id)
        {
            var failure = await _mediator.Send(new GetByIdQuery(id));
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

        [Route("failure/{id}/delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var failure = await _mediator.Send(new GetByIdQuery(id));
            var failureDeleteCommand = _mapper.Map<FailureDeleteCommand>(failure); 
            return View(failureDeleteCommand);
        }

        [HttpPost]
        [Route("failure/{id}/delete")]
        public async Task<IActionResult> Delete(FailureDeleteCommand command)
        {
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }
    }
}
