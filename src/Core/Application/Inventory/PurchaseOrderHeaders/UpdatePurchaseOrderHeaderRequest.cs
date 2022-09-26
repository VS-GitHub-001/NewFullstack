using FSH.WebApi.Domain.Common.Events;
using FSH.WebApi.Domain.Inventory;

namespace FSH.WebApi.Application.Inventory.PurchaseOrderHeaders;
public class UpdatePurchaseOrderHeaderRequest : IRequest<Guid>
{
    public Guid Id { get; set; }
    public Guid SupplierId { get; set; }
    public DateTime PurchaseOrderDate { get; set; }
    public decimal TotalAmount { get; set; }
    public string Code { get; set; } = default!;
    public string Note { get; set; } = default!;
}

public class UpdatePurchaseOrderHeaderRequestHandler : IRequestHandler<UpdatePurchaseOrderHeaderRequest, Guid>
{
    public readonly IRepository<PurchaseOrderHeader> _repository;
    private readonly IStringLocalizer _t;

    public UpdatePurchaseOrderHeaderRequestHandler(IRepository<PurchaseOrderHeader> repository, IStringLocalizer<UpdatePurchaseOrderHeaderRequestHandler> t)
    {
        _repository = repository;
        _t = t;
    }

    public async Task<Guid> Handle(UpdatePurchaseOrderHeaderRequest request, CancellationToken cancellationToken)
    {
        var purchaseOrderHeader = await _repository.GetByIdAsync(request.Id, cancellationToken);
        _ = purchaseOrderHeader ?? throw new NotFoundException(_t["Purchase Order {0} Not Found.", request.Id]);

        var updatePurchaseOrderHeader = purchaseOrderHeader.Update(request.SupplierId, request.PurchaseOrderDate, request.TotalAmount, request.Code, request.Note);

        // Add Domain Events to be raised after the commit
        purchaseOrderHeader.DomainEvents.Add(EntityUpdatedEvent.WithEntity(purchaseOrderHeader));

        await _repository.UpdateAsync(updatePurchaseOrderHeader, cancellationToken);

        return request.Id;
    }
}
