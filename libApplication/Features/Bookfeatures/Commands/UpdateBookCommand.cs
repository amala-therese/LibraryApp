using MediatR;
using libApplication.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace libApplication.Features.Bookfeatures.Commands
{
    public class UpdateBookCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public bool Availability { get; set; }
    }

    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public UpdateBookCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _context.books.FindAsync(request.Id);

            if (book != null)
            {
                book.Title = request.Title;
                book.Author = request.Author;
                book.Availability = request.Availability;

                await _context.SaveChangesAsync();
            }

            return request.Id; 
        }
    }
}
