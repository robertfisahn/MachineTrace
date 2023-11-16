using MachineTrace.Application.Dto.DailyReport;
using MediatR;

namespace MachineTrace.Application.Queries.DailyReport.GetById
{
    public class GetByIdQuery : IRequest<DailyReportDtoDetails>
    {
        public int Id { get; set; }
        public int? FromMachine { get; set; }

        public GetByIdQuery(int id, int? fromMachine)
        {
            Id = id;
            FromMachine = fromMachine;
        }

        public GetByIdQuery(int id)
        {
            Id = id;
        }
    }
}
