using libDomain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace libApplication.Interfaces
{
    public interface IApplicationDbContext
    {
    DbSet<Book> books { get; set;}
    DbSet<User> users { get; set;}

    DbSet<LendingHistory> lendingHistories { get; set;}
       
    Task<int> SaveChangesAsync();
    }
}