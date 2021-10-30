using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Interfaces.Repositories
{
    public interface IGadgetRepository
    {
        Task<IEnumerable<Gadget>> GetAllGadgets();
        Task<Gadget> GetGadgetById(int id);
        Task<Gadget> CreateGadget(Gadget feedback);
        Task<bool> DeleteGadget(int id);
    }
}
