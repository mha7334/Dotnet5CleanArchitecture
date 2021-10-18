using Microsoft.EntityFrameworkCore;

public class MyDbContext : DbContext, IMyDbContext
{

    
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) {}
    
    public DbSet<Gadget> Gadgets { get;  set;}
}
