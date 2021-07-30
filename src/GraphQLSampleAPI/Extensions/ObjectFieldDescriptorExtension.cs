using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQLSampleAPI.Extensions
{
    public static class ObjectFieldDescriptorExtension
    {
        public static IObjectFieldDescriptor UseDbContext<T>(this IObjectFieldDescriptor fieldDescriptor) where T : DbContext
        {
            return fieldDescriptor.UseScopedService<T>(
                create: services => services.GetRequiredService<IDbContextFactory<T>>().CreateDbContext(),
                dispose: (s, c) => c.DisposeAsync());
        }
    }
}