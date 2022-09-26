using FSH.WebApi.Application.Inventory.PurchaseOrderHeaders;
using FSH.WebApi.Application.Inventory.Suppliers;

namespace FSH.WebApi.Host.Controllers.Inventory;
public class PurchaseOrderHeadersController : VersionedApiController
{

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.PurchaseOrderHeaders)]
    [OpenApiOperation("Create new Purchase Order Headers.", "")]
    public Task<Guid> CreateAsync(CreatePurchaseOrderHeaderRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPost("search")]
    [MustHavePermission(FSHAction.Search, FSHResource.PurchaseOrderHeaders)]
    [OpenApiOperation("Search Purchase Order Headers using available filters.", "")]
    public Task<PaginationResponse<PurchaseOrderHeaderDto>> SearchAsync(SearchPurchaseOrderHeadersRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpGet("{id:guid}")]
    [MustHavePermission(FSHAction.View, FSHResource.PurchaseOrderHeaders)]
    [OpenApiOperation("Get Purchase Order Headers details.", "")]
    public Task<PurchaseOrderHeaderDto> GetAsync(Guid id)
    {
        return Mediator.Send(new GetPurchaseOrderHeaderRequest(id));
    }

 

    [HttpPut("{id:guid}")]
    [MustHavePermission(FSHAction.Update, FSHResource.PurchaseOrderHeaders)]
    [OpenApiOperation("Update a Purchase Order Headers.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdatePurchaseOrderHeaderRequest request, Guid id)
    {
        return id != request.Id

            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }


    [HttpDelete("{id:guid}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.PurchaseOrderHeaders)]
    [OpenApiOperation("Delete a Purchase Order Headers.", "")]
    public Task<Guid> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeletePurchaseOrderHeaderRequest(id));
    }
}
