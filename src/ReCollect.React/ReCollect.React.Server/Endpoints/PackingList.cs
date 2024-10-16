namespace ReCollect.Server.Endpoints;

using MediatR;
using Microsoft.AspNetCore.Mvc;
using ReCollect.Application.PackingList.Commands.AddPackingList;
using ReCollect.Application.PackingList.Queries.GetPackingList;
using ReCollect.Server.Infrastructure;

public class PackingList : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        //app.MapGet(GetPackingListById);
        //app.MapGroup(this).MapGet(GetPackingListById).MapPost(AddPackingList);
        var group = app.MapGroup(this.GetType().Name);

        group.MapGet("{packingListId:int}", GetPackingListById);
        group.MapPost("/add", AddPackingList);
    }

    private static Task<PackingListDto> GetPackingListById(
        ISender sender,
        [FromRoute] int packingListId
    )
    {
        return sender.Send(new GetPackingList(packingListId));
    }

    private static Task<int> AddPackingList(ISender sender, [FromBody] AddPackingList command) =>
        sender.Send(command);
}
