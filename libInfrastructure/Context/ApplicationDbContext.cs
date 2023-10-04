using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using libDomain.Entities;
using libApplication.Interfaces;

namespace libInfrastructure.Context;
public class ApplicationDbContext : DbContext,IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    public DbSet<Book> books { get; set;}
    public DbSet<User> users { get; set;}

    public DbSet<LendingHistory> lendingHistories { get; set;}

     public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

}