using MediatR;
using libApplication.Interfaces;
using libDomain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace libApplication.Features.LendingFeatures.Commands
{
    public class CreateLendingHistoryCommand : IRequest<int>
    {
        public int BookID { get; set; }
        public int UserID { get; set; }
        public DateTime LendDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }

    public class CreateLendingHistoryCommandHandler : IRequestHandler<CreateLendingHistoryCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateLendingHistoryCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateLendingHistoryCommand request, CancellationToken cancellationToken)
        {
            var lendingHistory = new LendingHistory
            {
                BookID = request.BookID,
                UserID = request.UserID,
                LendDate = request.LendDate,
                ReturnDate = request.ReturnDate
            };

            _context.lendingHistories.Add(lendingHistory);
            await _context.SaveChangesAsync();

            return lendingHistory.Id;
        }
    }
}

