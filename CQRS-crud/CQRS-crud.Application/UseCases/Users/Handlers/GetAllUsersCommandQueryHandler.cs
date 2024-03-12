using CQRS_crud.Application.Abstractions;
using CQRS_crud.Application.UseCases.Users.Queries;
using CQRS_crud.Domain.Entities.Models;
using MediatR;

namespace CQRS_crud.Application.UseCases.Users.Handlers
{
    public class GetAllUsersCommandQueryHandler : IRequestHandler<GetAllUsersCommandQuery, List<User>>
    {
        private readonly IAppDbContext _appDbContext;

        public GetAllUsersCommandQueryHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<User>> Handle(GetAllUsersCommandQuery request, CancellationToken cancellationToken)
        {
            return _appDbContext.Users.ToList();
        }
    }
}
