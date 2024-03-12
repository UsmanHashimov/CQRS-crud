using CQRS_crud.Application.Abstractions;
using CQRS_crud.Application.UseCases.Users.Queries;
using CQRS_crud.Domain.Entities.Exceptions;
using CQRS_crud.Domain.Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS_crud.Application.UseCases.Users.Handlers
{
    public class GetUserByIdCommandQueryHandler : IRequestHandler<GetUserByIdCommandQuery, User>
    {
        private readonly IAppDbContext _appDbContext;

        public GetUserByIdCommandQueryHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<User> Handle(GetUserByIdCommandQuery request, CancellationToken cancellationToken)
        {
            var res = await _appDbContext.Users.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (res == null) throw new UserNotFoundException("Such user not found");

            return res;
        }
    }
}
