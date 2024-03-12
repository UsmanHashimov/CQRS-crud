using CQRS_crud.Domain.Entities.Models;
using MediatR;

namespace CQRS_crud.Application.UseCases.Users.Queries
{
    public class GetAllUsersCommandQuery : IRequest<List<User>>
    {
    }
}
