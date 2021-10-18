using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Interfaces.Services
{
    public interface IGadgetService
    {
        Task<IEnumerable<Gadget>> GetAllGadgets();
    }
}