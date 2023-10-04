using libApplication.Interfaces;
using libDomain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace libApplication.Features.Bookfeatures.Commands
{
    public class AddBookCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public bool Availability { get; set; }
    }

    public class AddBookCommandHandler : IRequestHandler<AddBookCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public AddBookCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(AddBookCommand request,CancellationToken cancellationToken)
        {
            var book = new Book
            {
                Title = request.Title,
                Author = request.Author,
                Availability = request.Availability
            };

            _context.books.Add(book);
            await _context.SaveChangesAsync();

            return book.Id;
        }
    }
}
