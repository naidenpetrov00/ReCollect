namespace ReCollect.Server.Endpoints;

using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ReCollect.Application.PackingList.Commands.AddPackingList;
using ReCollect.Application.PackingList.Queries.GetPackingList;
using ReCollect.Server.Infrastructure;

public class PackingList : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        var group = app.MapGroup(this.GetType().Name);

        group.MapGet("/{packingListId:int}", GetPackingListById);
        group.MapGet(
            "/withTypedResultReturn/{packingListId:int}",
            GetPackingListByIdWithTypedResultReturn
        );
        group.MapPost("/add", CreatePackingList);
    }

    private static async Task<Ok<PackingListDto>> GetPackingListByIdWithTypedResultReturn(
        int packingListId,
        ISender sender
    ) => TypedResults.Ok(await sender.Send(new GetPackingList(packingListId)));

    private static Task<PackingListDto> GetPackingListById(int packingListId, ISender sender) =>
        sender.Send(new GetPackingList(packingListId));

    private static async Task<Results<Created<int>, BadRequest>> CreatePackingList(
        ISender sender,
        [FromBody] AddPackingList command
    )
    {
        var id = await sender.Send(command);
        return TypedResults.Created($"/{nameof(PackingList)}/add", id);
    }
}
