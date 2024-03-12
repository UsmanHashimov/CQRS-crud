using AutoMapper;
using CQRS_crud.Application.Abstractions;
using CQRS_crud.Application.UseCases.Users.Commands;
using CQRS_crud.Domain.Entities.Models;
using Mapster;
using MediatR;

namespace CQRS_crud.Application.UseCases.Users.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = request.Adapt<User>();
            var res = await _context.Users.AddAsync(user);
            await _context.MySaveChangesAsync(cancellationToken);
            return user;
        }
    }
}
