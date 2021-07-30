using System.Reflection;
using GraphQLSampleAPI.Contexts;
using GraphQLSampleAPI.Extensions;
using HotChocolate.Types;
using HotChocolate.Types.Descriptors;

namespace GraphQLSampleAPI.Attributes
{
    public class UseApplicationDbContextAttribute : ObjectFieldDescriptorAttribute
    {
        public override void OnConfigure(IDescriptorContext context, IObjectFieldDescriptor descriptor, MemberInfo member)
        {
            descriptor.UseDbContext<ApplicationDbContext>();
        }
    }
}