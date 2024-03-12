using CQRS_crud.Application.Abstractions;
using CQRS_crud.Application.UseCases.Users.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS_crud.Application.UseCases.Users.Handlers
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, string>
    {
        private readonly IAppDbContext _context;

        public UpdateUserCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var res = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.IdToFind);
            if (res == null) return "User not found";
            if (request.OldPassword != res.Password) return "Incorrect password!";

            if (!string.IsNullOrEmpty(request.Name)) res.Name = request.Name;
            if (!string.IsNullOrEmpty(request.Email)) res.Email = request.Email;
            if (!string.IsNullOrEmpty(request.NewPassword)) res.Password = request.NewPassword;

            _context.Users.Update(res);
            await _context.MySaveChangesAsync(cancellationToken);
            return "Updated!";
        }
    }
}
