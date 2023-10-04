using MediatR;
using Microsoft.EntityFrameworkCore;
using libApplication.Interfaces;
using libDomain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace libApplication.Features.UserFeatures.Queries
{
    public class GetAllUsersQuery : IRequest<List<User>>
    {
    }

    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<User>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllUsersQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _context.users.ToListAsync(cancellationToken);
            return users;
        }
    }
}
