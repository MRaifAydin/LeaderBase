using AutoMapper;
using LeaderBase.Core.Common;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBase.Conversion
{
    public static class ConversionExtension
    {
        public static TDestination Map<TDestination>(this object source)
        {
            return ServiceLocator.ResolveService<IMapper>().Map<TDestination>(source);
        }
        public static TDestination Map<TDestination>(this object source, Action<IMappingOperationOptions<object, TDestination>> opts)
        {
            return ServiceLocator.ResolveService<IMapper>().Map(source, opts);
        }

        public static async Task<TDestination> MapAsync<TSource, TDestination>(this Task<TSource> source) where TSource : class where TDestination : class
        {
            return ServiceLocator.ResolveService<IMapper>().Map<TDestination>(await source);
        }

        public static IMongoQueryable<TDestination> ProjectTo<TDestination>(this IMongoQueryable sources)
        {
            var mapper = ServiceLocator.ResolveService<IMapper>();
            return (IMongoQueryable<TDestination>)mapper.ProjectTo<TDestination>(sources);
        }
    }
}
