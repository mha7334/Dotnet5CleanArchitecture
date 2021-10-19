using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Application.Interfaces.Data;
using CleanArchitecture.Application.Interfaces.Repositories;
using CleanArchitecture.Application.Interfaces.Services;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Services
{
    public class GadgetService : IGadgetService
    {
        private readonly IGadgetRepository _repository;


        public GadgetService(IGadgetRepository repository)
        {
            _repository = repository?? throw new ArgumentNullException(nameof(repository));
        }
        public async Task<IEnumerable<Gadget>> GetAllGadgets()
        {
            return await _repository.GetAllGadgets();
        }
    }
}
