using MediatR;

namespace CQRS_crud.Application.UseCases.Users.Commands
{
    public class DeleteUserCommand : IRequest<string>
    {
        public int IdToFind { get; set; }
        public string Password { get; set; }
    }
}
