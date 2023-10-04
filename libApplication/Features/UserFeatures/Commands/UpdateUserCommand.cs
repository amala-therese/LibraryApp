using MediatR;
using libApplication.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace libApplication.Features.UserFeatures.Commands
{
    public class UpdateUserCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }

    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public UpdateUserCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.users.FindAsync(request.Id);

            if (user != null)
            {
                user.firstName = request.FirstName;
                user.lastName = request.LastName;
                user.email = request.Email;

                await _context.SaveChangesAsync();
            }

            return request.Id; 
        }
    }
}
