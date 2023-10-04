using MediatR;
using Microsoft.EntityFrameworkCore;
using libApplication.Interfaces;
using libDomain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace libApplication.Features.LendingFeatures.Queries
{
    public class GetAllLendingHistoriesQuery : IRequest<List<LendingHistory>>
    {
    }

    public class GetAllLendingHistoriesQueryHandler : IRequestHandler<GetAllLendingHistoriesQuery, List<LendingHistory>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllLendingHistoriesQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<LendingHistory>> Handle(GetAllLendingHistoriesQuery request, CancellationToken cancellationToken)
        {
            var Histories = await _context.lendingHistories.ToListAsync(cancellationToken);
            return Histories;
        }
    }
}
