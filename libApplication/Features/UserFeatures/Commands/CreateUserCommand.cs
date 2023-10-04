
using MediatR;
using libApplication.Interfaces;
using libDomain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace libApplication.Features.UserFeatures.Commands
{
    public class CreateUserCommand : IRequest<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateUserCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                firstName = request.FirstName,
                lastName = request.LastName,
                email = request.Email
            };

            _context.users.Add(user);
            await _context.SaveChangesAsync();

            return user.id;
        }
    }
}
