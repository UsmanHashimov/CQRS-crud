using MediatR;

namespace CQRS_crud.Application.UseCases.Users.Commands
{
    public class UpdateUserCommand : IRequest<string>
    {
        public int IdToFind { get; set; }
        public string OldPassword { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string NewPassword { get; set; }
    }
}
