using MediatR;
using Microsoft.EntityFrameworkCore;
using libApplication.Interfaces;
using libDomain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace libApplication.Features.Bookfeatures.Queries
{
    public class GetAllBooksQuery : IRequest<List<Book>>
    {
    }

    public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, List<Book>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllBooksQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var books = await _context.books.ToListAsync();
            return books;
        }
    }
}
