
using FSH.WebApi.Domain.Common.Events;
using FSH.WebApi.Domain.Inventory;

namespace FSH.WebApi.Application.Inventory.PurchaseOrders;
public class UpdatePurchaseOrderRequest : IRequest<Guid>
{
    public Guid Id { get; set; }
    public Guid PurchaseOrderHeaderId { get; set; }
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    public Guid ProductId { get; set; }
}

public class UpdatePurchaseOrderRequestHandler : IRequestHandler<UpdatePurchaseOrderRequest, Guid>
{
    public readonly IRepository<PurchaseOrder> _repository;
    private readonly IStringLocalizer _t;

    public UpdatePurchaseOrderRequestHandler(IRepository<PurchaseOrder> repository, IStringLocalizer<UpdatePurchaseOrderRequestHandler> t)
    {
        _repository = repository;
        _t = t;
    }

    public async Task<Guid> Handle(UpdatePurchaseOrderRequest request, CancellationToken cancellationToken)
    {
        var purchaseOrder = await _repository.GetByIdAsync(request.Id, cancellationToken);
        _ = purchaseOrder ?? throw new NotFoundException(_t["Purchase Order {0} Not Found.", request.Id]);

        var updatePurchaseOrder = purchaseOrder.Update(request.PurchaseOrderHeaderId, request.UnitPrice, request.Quantity, request.ProductId);

        // Add Domain Events to be raised after the commit
        purchaseOrder.DomainEvents.Add(EntityUpdatedEvent.WithEntity(purchaseOrder));

        await _repository.UpdateAsync(updatePurchaseOrder, cancellationToken);

        return request.Id;
    }
}
