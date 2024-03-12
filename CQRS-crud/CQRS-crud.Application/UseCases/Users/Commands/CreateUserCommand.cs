using CQRS_crud.Domain.Entities.Models;
using MediatR;

namespace CQRS_crud.Application.UseCases.Users.Commands
{
    public class CreateUserCommand : IRequest<User>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
