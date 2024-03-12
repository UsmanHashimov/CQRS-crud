using CQRS_crud.Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRS_crud.Application.Abstractions
{
    public interface IAppDbContext
    {
        public DbSet<User> Users { get; set; }

        public ValueTask<int> MySaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
