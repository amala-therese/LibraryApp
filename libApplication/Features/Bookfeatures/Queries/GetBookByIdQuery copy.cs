using MediatR;
using Microsoft.EntityFrameworkCore;
using libApplication.Interfaces;
using libDomain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace libApplication.Features.Bookfeatures.Queries
{
    public class GetBookByIdQuery : IRequest<Book>
    {
        public int Id { get; set; }
    }

    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, Book>
    {
        private readonly IApplicationDbContext _context;

        public GetBookByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Book> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _context.books.FindAsync(request.Id);
            return book;
        }
    }
}
