using FSH.WebApi.Application.Inventory.PurchaseOrders;
using FSH.WebApi.Application.Inventory.Suppliers;

namespace FSH.WebApi.Host.Controllers.Inventory;
public class PurchaseOrderController : VersionedApiController
{
    [HttpPost("search")]
    [MustHavePermission(FSHAction.Search, FSHResource.PurchaseOrder)]
    [OpenApiOperation("Search Purchase Order using available filters.", "")]
    public Task<PaginationResponse<PurchaseOrderDto>> SearchAsync(SearchPurchaseOrderRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpGet("{id:guid}")]
    [MustHavePermission(FSHAction.View, FSHResource.PurchaseOrder)]
    [OpenApiOperation("Get Purchase Order details.", "")]
    public Task<PurchaseOrderDetailsDto> GetAsync(Guid id)
    {
        return Mediator.Send(new GetPurchaseOrderRequest(id));
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.PurchaseOrder)]
    [OpenApiOperation("Create a new Purchase Order.", "")]
    public Task<Guid> CreateAsync(CreatePurchaseOrderRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    [MustHavePermission(FSHAction.Update, FSHResource.PurchaseOrder)]
    [OpenApiOperation("Update a purchase order.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdatePurchaseOrderRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.PurchaseOrder)]
    [OpenApiOperation("Delete a Purchase Order.", "")]
    public Task<Guid> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeletePurchaseOrderRequest(id));
    }
}
