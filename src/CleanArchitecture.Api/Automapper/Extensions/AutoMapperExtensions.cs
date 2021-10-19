using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Api.Automapper;

namespace CleanArchitecture.Api.Extensions
{
    public static class MapperExtension
    {
        public static List<TDest> MapList<TSource, TDest>(this List<TSource> list)
        {
            return list.Select(c => GadgetMapper.I.Map<TDest>(c)).ToList();
        }
        public static List<TDest> MapList<TSource, TDest>(this IEnumerable<TSource> list)
    {
        return list.Select(c => GadgetMapper.I.Map<TDest>(c)).ToList();
    }
        public static TDest Map<TDest>(this object obj)
        {
            return GadgetMapper.I.Map<TDest>(obj);
        }

    }
}
