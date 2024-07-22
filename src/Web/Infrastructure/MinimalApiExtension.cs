using System.Reflection;

namespace CleanArchitecture.Web.Infrastructure;

public static class WebApplicationExtensions
{
    public static RouteGroupBuilder MapGroup(this WebApplication app, IEndpoint group)
    {
        string? groupName = group.name;

        return app
            .MapGroup($"/api/{groupName}")
            .WithGroupName(groupName)
            .WithTags(groupName)
            .WithOpenApi();
    }

    public static WebApplication MapEndpoints(this WebApplication app)
    {
        Type? endpointGroupType = typeof(IEndpoint);
        Assembly? assembly = Assembly.GetExecutingAssembly();
        IEnumerable<Type>? endpointGroupTypes = assembly.GetExportedTypes()
            .Where(t => t.IsSubclassOf(endpointGroupType));

        foreach (Type type in endpointGroupTypes)
        {
            if (Activator.CreateInstance(type) is IEndpoint instance)
            {
                instance.RegisterEndpoints(app);
            }
        }

        return app;
    }
}
