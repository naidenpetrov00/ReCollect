namespace ReCollect.Server.Endpoints;

using ReCollect.Server.Infrastructure;

public class PackingList : EndpointGroupBase
{
    public override void Map(WebApplication app)
	{
		app.MapGroup(this)
			.MapGet(GetGetPackingList);
	}

	private static object GetGetPackingList() => ;
}
