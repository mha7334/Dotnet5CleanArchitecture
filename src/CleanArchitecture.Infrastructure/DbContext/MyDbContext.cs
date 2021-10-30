using CleanArchitecture.Application.Interfaces.Data;
using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.DbContext
{
    public class MyDbContext : Microsoft.EntityFrameworkCore.DbContext, IMyDbContext
    {


        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) {}
    
        public DbSet<Gadget> Gadgets { get;  set;}
    }
}
