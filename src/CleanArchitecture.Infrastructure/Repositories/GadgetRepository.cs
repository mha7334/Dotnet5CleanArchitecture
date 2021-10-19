using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Interfaces.Data;
using CleanArchitecture.Application.Interfaces.Repositories;
using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Repositories
{
     public class GadgetRepository: IGadgetRepository
    {
        private readonly IMyDbContext _context;

        public GadgetRepository(IMyDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


        public async  Task<IEnumerable<Gadget>> GetAllGadgets()
        {
            return await _context.Gadgets.ToListAsync();
        }

        public Task<Gadget> GetGadgetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateGadget(Gadget feedback)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteGadget(int id)
        {
            throw new NotImplementedException();
        }
    }
}
