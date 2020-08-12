using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using campus_api.Repositories.Entities;
using CampusISApi.Model;

namespace campus_api.Services.Mappers
{
    public class EnumerableMapper<TSource, TDestination> : IMapper<IEnumerable<TSource>, IEnumerable<TDestination>>
    {
        private readonly IMapper<TSource, TDestination> _singleMapper;

        public EnumerableMapper(IMapper<TSource, TDestination> singleMapper)
        {
            _singleMapper = singleMapper ?? throw new ArgumentNullException(nameof(singleMapper));
        }

        public IEnumerable<TDestination> Map(IEnumerable<TSource> source)
        {
            var count = source.Count();
            var destination = new TDestination[count];
            for (int i = 0; i < count; i++)
            {
                var currentSource = source.ElementAt(i);
                var currentDestination = _singleMapper.Map(currentSource);
                destination[i] = currentDestination;
            }
            return destination;
        }
    }
}