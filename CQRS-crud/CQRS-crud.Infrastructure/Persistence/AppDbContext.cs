using CQRS_crud.Application.Abstractions;
using CQRS_crud.Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRS_crud.Infrastructure.Persistence
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public async ValueTask<int> MySaveChangesAsync(CancellationToken cancellationToken)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
