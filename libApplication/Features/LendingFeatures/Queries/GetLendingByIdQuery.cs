using MediatR;
using libApplication.Interfaces;
using libDomain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace libApplication.Features.LendingFeatures.Queries
{
    public class GetLendingHistoryByIdQuery : IRequest<LendingHistory>
    {
        public int Id { get; set; }
    }

    public class GetLendingHistoryByIdQueryHandler : IRequestHandler<GetLendingHistoryByIdQuery, LendingHistory>
    {
        private readonly IApplicationDbContext _context;

        public GetLendingHistoryByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<LendingHistory> Handle(GetLendingHistoryByIdQuery request, CancellationToken cancellationToken)
        {
            var lendingHistory = await _context.lendingHistories.FindAsync(request.Id);
            return lendingHistory;
        }
    }
}
