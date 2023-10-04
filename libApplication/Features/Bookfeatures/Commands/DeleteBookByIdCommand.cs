using MediatR;
using libApplication.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace libApplication.Features.Bookfeatures.Commands
{
    public class DeleteBookCommand : IRequest<int>
    {
        public int Id { get; set; }
    }

    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public DeleteBookCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _context.books.FindAsync(request.Id);

            if (book != null)
            {
                _context.books.Remove(book);
                await _context.SaveChangesAsync();
            }

            return request.Id; 
        }
    }
}

