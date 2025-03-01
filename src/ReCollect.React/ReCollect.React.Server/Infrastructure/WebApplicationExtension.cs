﻿namespace ReCollect.Server.Infrastructure;

using System.Reflection;

public static class WebApplicationExtension
{
    public static WebApplication MapEndpoints(this WebApplication app)
    {
        var assebmly = Assembly.GetExecutingAssembly();
        var endpointGroupType = typeof(EndpointGroupBase);
        var endpointGroups = assebmly
            .GetExportedTypes()
            .Where(t => t.IsSubclassOf(endpointGroupType));

        foreach (var group in endpointGroups)
        {
            if (Activator.CreateInstance(group) is EndpointGroupBase instance)
            {
                instance.Map(app);
            }
        }

        return app;
    }
}
