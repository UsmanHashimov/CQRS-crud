using CQRS_crud.Application.Abstractions;
using CQRS_crud.Application.UseCases.Users.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS_crud.Application.UseCases.Users.Handlers
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, string>
    {
        private readonly IAppDbContext _context;

        public DeleteUserCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var res = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.IdToFind);
            if (res == null) return "Such user not found";
            if (request.Password != res.Password) return "Incorrect password";

            _context.Users.Remove(res);
            await _context.MySaveChangesAsync(cancellationToken);
            return "Deleted";
        }
    }
}
