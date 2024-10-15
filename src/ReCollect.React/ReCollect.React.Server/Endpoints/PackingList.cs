namespace ReCollect.Server.Endpoints;

using MediatR;
using ReCollect.Application.PackingList.Commands.AddPackingList;
using ReCollect.Application.PackingList.Queries.GetPackingList;
using ReCollect.Server.Infrastructure;

public class PackingList : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this).MapGet(GetPackingListById).MapPost(AddPackingList);
    }

    private static async Task<PackingListDto> GetPackingListById(
        ISender sender,
        GetPackingList command
    ) => await sender.Send(command);

    private static Task<int> AddPackingList(ISender sender, AddPackingList command) =>
        sender.Send(command);
}
