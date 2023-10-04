using MediatR;
using libApplication.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace libApplication.Features.UserFeatures.Commands
{
    public class DeleteUserCommand : IRequest<int>
    {
        public int Id { get; set; }
    }

    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public DeleteUserCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.users.FindAsync(request.Id);

            if (user != null)
            {
                _context.users.Remove(user);
                await _context.SaveChangesAsync();
            }

            return request.Id; 
        }
    }
}

