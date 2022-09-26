using FSH.WebApi.Domain.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Application.Inventory.PurchaseOrderHeaders;
public class PurchaseOrderHeaderBySeearchRequestWithSupplierSpec : EntitiesByPaginationFilterSpec<PurchaseOrderHeader, PurchaseOrderHeaderDto>
{
    public PurchaseOrderHeaderBySeearchRequestWithSupplierSpec(SearchPurchaseOrderHeadersRequest request)
        : base(request) => Query.Include(p => p.Supplier)
            .OrderBy(c => c.Supplier.Name, !request.HasOrderBy())
            .Where(p => p.Supplier.Name.Contains(request.SupplierName))
            .Where(p => p.Code.Contains(request.Code));

        
}
