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
        // var group = app.MapGroupp(this);
        var group = app.MapGroup(this.GetType().Name);

        group
            .MapGet("/{packingListId:int}", GetPackingListById)
            .Produces<PackingListDto>(StatusCodes.Status200OK)
            .WithName("Get packing list by id");
        group.MapGet("/withReturn/{packingListId:int}", GetPackingListByIdWithResultReturn);
        group.MapPost("/add", AddPackingList);
    }

    private static async Task<IResult> GetPackingListByIdWithResultReturn(
        int packingListId,
        ISender sender
    ) => Results.Json(await sender.Send(new GetPackingList(packingListId)));

    private static Task<PackingListDto> GetPackingListById(int packingListId, ISender sender) =>
        sender.Send(new GetPackingList(packingListId));

    private static Task<int> AddPackingList(ISender sender, [FromBody] AddPackingList command) =>
        sender.Send(command);
}
