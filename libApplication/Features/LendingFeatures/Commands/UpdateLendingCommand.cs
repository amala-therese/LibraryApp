using MediatR;
using libApplication.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace libApplication.Features.LendingFeatures.Commands
{
    public class UpdateLendingHistoryCommand : IRequest<int>
    {
        public int LendingID { get; set; }
        public int BookID { get; set; }
        public int UserID { get; set; }
        public DateTime LendDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }

    public class UpdateLendingHistoryCommandHandler : IRequestHandler<UpdateLendingHistoryCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public UpdateLendingHistoryCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateLendingHistoryCommand request, CancellationToken cancellationToken)
        {
            var lendingHistory = await _context.lendingHistories.FindAsync(request.LendingID);

            if (lendingHistory != null)
            {
                lendingHistory.BookID = request.BookID;
                lendingHistory.UserID = request.UserID;
                lendingHistory.LendDate = request.LendDate;
                lendingHistory.ReturnDate = request.ReturnDate;

                await _context.SaveChangesAsync();
            }

            return lendingHistory.Id;
        }
    }
}

