using Microsoft.EntityFrameworkCore;

public interface IMyDbContext
{
    public DbSet<Gadget> Gadgets {get; set;}
} 