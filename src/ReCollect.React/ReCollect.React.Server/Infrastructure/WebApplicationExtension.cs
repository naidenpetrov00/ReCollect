namespace ReCollect.Server.Infrastructure;

public static class WebApplicationExtension
{
    public static RouteGroupBuilder MapGroup(this WebApplication app, EndpointGroupBase groupBase)
    {
        var groupName = groupBase.GetType().Name;

        return app.MapGroup($"api/{groupName}")
            .WithGroupName(groupName)
            .WithTags(groupName)
            .WithOpenApi();
    }
}
