using System.Collections.Generic;
using System.Linq;

public class GadgetService : IGadgetService
{
    private readonly IMyDbContext context;

    public GadgetService(IMyDbContext context)
    {
        this.context = context;
    }
    public List<GadgetDto> GetAllGadgets()
    {
        return this.context.Gadgets.Select(_ => new GadgetDto { Id = _.Id, Name = _.Name}).ToList();
    }
}
