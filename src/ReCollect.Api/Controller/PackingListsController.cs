namespace ReCollect.Api.Controller;

using MediatR;
using Microsoft.AspNetCore.Mvc;
using ReCollect.Application.PackingList.Commands.AddPackingItem;
using ReCollect.Application.PackingList.Commands.CreatePackingList;
using ReCollect.Application.PackingList.Commands.PackItem;
using ReCollect.Application.PackingList.Commands.RemovePackingItem;
using ReCollect.Application.PackingList.Commands.RemovePackingList;
using ReCollect.Application.PackingList.Queries.GetPackingList;
using ReCollect.Application.PackingList.Queries.SearchPackingLists;

public class PackingListsController : BaseController
{
    private readonly IMediator mediator;

    public PackingListsController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<PackingListDto>> Get([FromRoute] GetPackingList query)
    {
        var result = await this.mediator.Send(query);

        return this.OkOrNotFound(result);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PackingListDto>>> Get(
        [FromQuery] SearchPackingLists query
    )
    {
        var result = await this.mediator.Send(query);

        return this.OkOrNotFound(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreatePackingListWithItems command)
    {
        await this.mediator.Send(command);
        return CreatedAtAction(nameof(Get), new { id = command.Id }, null);
    }

    [HttpPut("{packingListId:guid}/items")]
    public async Task<IActionResult> Put(AddPackingItem command)
    {
        await this.mediator.Send(command);
        return Ok();
    }

    [HttpPut("{packingListId:guid}/items/{name}/pack")]
    public async Task<IActionResult> Put(PackItem command)
    {
        await this.mediator.Send(command);
        return Ok();
    }

    [HttpDelete("{packingListId:guid}/items/{name}")]
    public async Task<IActionResult> Delete(RemovePackingItem command)
    {
        await this.mediator.Send(command);
        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(RemovePackingList command)
    {
        await this.mediator.Send(command);
        return Ok();
    }
}
