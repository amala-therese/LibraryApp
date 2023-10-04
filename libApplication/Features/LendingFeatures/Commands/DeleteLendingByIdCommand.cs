using MediatR;
using libApplication.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace libApplication.Features.LendingFeatures.Commands
{
    public class DeleteLendingHistoryCommand : IRequest<int>
    {
        public int Id { get; set; }
    }

    public class DeleteLendingHistoryCommandHandler : IRequestHandler<DeleteLendingHistoryCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public DeleteLendingHistoryCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteLendingHistoryCommand request, CancellationToken cancellationToken)
        {
            var lendingHistory = await _context.lendingHistories.FindAsync(request.Id);

            if (lendingHistory != null)
            {
                _context.lendingHistories.Remove(lendingHistory);
                await _context.SaveChangesAsync();
            }

            return lendingHistory.Id;
        }
    }
}
