using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace CleanArchitecture.Api.Automapper
{
    public class GadgetMapper
    {
        private static IMapper _mapper;

        public static IMapper I
        {
            get
            {
                if (_mapper == null)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.AddProfile<GadgetMapperProfile>();
                    });
                    _mapper = config.CreateMapper();
                }
                return _mapper;
            }
        }
    }
}
