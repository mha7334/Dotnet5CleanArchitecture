using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

        public async Task<Gadget> GetGadgetById(int id)
        {
            return await _context.Gadgets.FindAsync(id);
        }

        public async Task<Gadget> CreateGadget(Gadget feedback)
        {
            throw new NotImplementedException();
            //await _context.Gadgets.AddAsync(feedback);
            //_context.Gadgets.Attach(feedback);
            //_context.SaveChangesAsync();
        }

        public Task<bool> DeleteGadget(int id)
        {
            return Task.FromResult(true);
        }
        
    }
}
