using CQRS_crud.Domain.Entities.Models;
using MediatR;

namespace CQRS_crud.Application.UseCases.Users.Queries
{
    public class GetUserByIdCommandQuery : IRequest<User>
    {
        public int Id { get; set; }
    }
}
