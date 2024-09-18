using AutoMapper;
using System.Collections.Immutable;

namespace SSTHub.Infrastructure.MappingProfiles.CustomConverters
{
    public class ImmutableListConverter<S, D> : ITypeConverter<ImmutableList<S>, ImmutableList<D>> where S : class
                                                                                                   where D : class
    {
        ImmutableList<D> ITypeConverter<ImmutableList<S>, ImmutableList<D>>.Convert(
            ImmutableList<S> source,
            ImmutableList<D> destination,
            ResolutionContext context)
        {
            var builder = ImmutableList.CreateBuilder<D>();

            foreach (var item in source)
            {
                builder.Add(context.Mapper.Map<D>(item));
            }

            return builder.ToImmutable();
        }
    }
}
