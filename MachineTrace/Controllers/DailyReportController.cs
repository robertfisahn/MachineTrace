using AutoMapper;
using MachineTrace.Application.Commands.DailyReport.Create;
using MachineTrace.Application.Commands.DailyReport.Delete;
using MachineTrace.Application.Commands.DailyReport.Edit;
using MachineTrace.Application.Queries.DailyReport.CreateForm;
using MachineTrace.Application.Queries.DailyReport.EditForm;
using MachineTrace.Application.Queries.DailyReport.GetAll;
using MachineTrace.Application.Queries.DailyReport.GetById;
using MachineTrace.Application.Queries.DailyReport.GetByMachine;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MachineTrace.Controllers
{
    public class DailyReportController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public DailyReportController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var reports = await _mediator.Send(new GetAllQuery());
            return View(reports);
        }
        [Route("machine/{machineId}/dailyReports")]
        public async Task<IActionResult> ByMachine(int machineId)
        {
            var reports = await _mediator.Send(new GetByMachineQuery(machineId));
            return View(reports);
        }

        [Route("machine/{machineId}/dailyReport")]
        public async Task<IActionResult> Create(int machineId)
        {
            var createForm = await _mediator.Send(new CreateFormQuery(machineId));
            var createCommand = _mapper.Map<DailyReportCreateCommand>(createForm);
            return View(createCommand);
        }

        [HttpPost]
        [Route("machine/{machineId}/dailyReport")]
        public async Task<IActionResult> Create(DailyReportCreateCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }
            await _mediator.Send(command);
            return RedirectToAction("Details", "Machine", new { id = command.MachineId });
        }

        [Route("dailyReport/{id}/details")]
        [Route("machine/{machineId}/dailyReport/{id}/details")]
        public async Task<IActionResult> Details(int id, int? machineId)
        {
            var report = await _mediator.Send(new GetByIdQuery(id, machineId));
            return View(report);
        }

        [Route("dailyReport/{id}/delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var report = await _mediator.Send(new GetByIdQuery(id));
            var deleteCommand = _mapper.Map<DailyReportDeleteCommand>(report);
            return View(deleteCommand);
        }

        [HttpPost]
        [Route("dailyReport/{id}/delete")]
        public async Task<IActionResult> Delete(DailyReportDeleteCommand command)
        {
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

        [Route("dailyReport/{id}/edit")]
        public async Task<IActionResult> Edit(int id)
        {
            var report = await _mediator.Send(new EditFormQuery(id));
            var editCommand = _mapper.Map<DailyReportEditCommand>(report);
            return View(editCommand);
        }

        [HttpPost]
        [Route("dailyReport/{id}/edit")]
        public async Task<IActionResult> Edit(DailyReportEditCommand command)
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
