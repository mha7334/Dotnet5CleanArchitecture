using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Interfaces.Data
{
    public interface IMyDbContext
    {
        public DbSet<Gadget> Gadgets {get; set;}
    }
} 