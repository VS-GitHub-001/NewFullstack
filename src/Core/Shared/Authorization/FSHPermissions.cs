using System.Collections.ObjectModel;

namespace FSH.WebApi.Shared.Authorization;


public static class FSHAction
{
    public const string View = nameof(View);
    public const string Search = nameof(Search);
    public const string Create = nameof(Create);
    public const string Update = nameof(Update);
    public const string Delete = nameof(Delete);
    public const string Export = nameof(Export);
    public const string Generate = nameof(Generate);
    public const string Clean = nameof(Clean);
    public const string UpgradeSubscription = nameof(UpgradeSubscription);
}

public static class FSHResource
{
    public const string Tenants = nameof(Tenants);
    public const string Dashboard = nameof(Dashboard);
    public const string Hangfire = nameof(Hangfire);
    public const string Users = nameof(Users);
    public const string UserRoles = nameof(UserRoles);
    public const string Roles = nameof(Roles);
    public const string RoleClaims = nameof(RoleClaims);
    public const string Products = nameof(Products);
    public const string Brands = nameof(Brands);
    public const string Categories = nameof(Categories);
    public const string UnitsOfMeasurements = nameof(UnitsOfMeasurements);
    public const string UnitsOfMeasurementsConversion = nameof(UnitsOfMeasurementsConversion);
    public const string Suppliers = nameof(Suppliers);
    public const string PurchaseOrderHeaders = nameof(PurchaseOrderHeaders);
    public const string PurchaseOrder = nameof(PurchaseOrder);
}

public static class FSHPermissions
{
    private static readonly FSHPermission[] _all = new FSHPermission[]
    {
        new("View Dashboard", FSHAction.View, FSHResource.Dashboard),
        new("View Hangfire", FSHAction.View, FSHResource.Hangfire),
        new("View Users", FSHAction.View, FSHResource.Users),
        new("Search Users", FSHAction.Search, FSHResource.Users),
        new("Create Users", FSHAction.Create, FSHResource.Users),
        new("Update Users", FSHAction.Update, FSHResource.Users),
        new("Delete Users", FSHAction.Delete, FSHResource.Users),
        new("Export Users", FSHAction.Export, FSHResource.Users),
        new("View UserRoles", FSHAction.View, FSHResource.UserRoles),
        new("Update UserRoles", FSHAction.Update, FSHResource.UserRoles),
        new("View Roles", FSHAction.View, FSHResource.Roles),
        new("Create Roles", FSHAction.Create, FSHResource.Roles),
        new("Update Roles", FSHAction.Update, FSHResource.Roles),
        new("Delete Roles", FSHAction.Delete, FSHResource.Roles),
        new("View RoleClaims", FSHAction.View, FSHResource.RoleClaims),
        new("Update RoleClaims", FSHAction.Update, FSHResource.RoleClaims),
        new("View Products", FSHAction.View, FSHResource.Products, IsBasic: true),
        new("Search Products", FSHAction.Search, FSHResource.Products, IsBasic: true),
        new("Create Products", FSHAction.Create, FSHResource.Products),
        new("Update Products", FSHAction.Update, FSHResource.Products),
        new("Delete Products", FSHAction.Delete, FSHResource.Products),
        new("Export Products", FSHAction.Export, FSHResource.Products),
        new("View Brands", FSHAction.View, FSHResource.Brands, IsBasic: true),
        new("Search Brands", FSHAction.Search, FSHResource.Brands, IsBasic: true),
        new("Create Brands", FSHAction.Create, FSHResource.Brands),
        new("Update Brands", FSHAction.Update, FSHResource.Brands),
        new("Delete Brands", FSHAction.Delete, FSHResource.Brands),
        new("Generate Brands", FSHAction.Generate, FSHResource.Brands),
        new("Clean Brands", FSHAction.Clean, FSHResource.Brands),
        new("Search Category", FSHAction.Search, FSHResource.Categories, IsBasic: true),
        new("View Categories", FSHAction.View, FSHResource.Categories, IsBasic: true),
        new("Create Categories", FSHAction.Create, FSHResource.Categories),
        new("Update Categories", FSHAction.Update, FSHResource.Categories),
        new("Delete Categories", FSHAction.Delete, FSHResource.Categories),
        new("Search UnitsOfMeasurements", FSHAction.Search, FSHResource.UnitsOfMeasurements, IsBasic: true),
        new("View UnitsOfMeasurements", FSHAction.View, FSHResource.UnitsOfMeasurements, IsBasic: true),
        new("Create UnitsOfMeasurements", FSHAction.Create, FSHResource.UnitsOfMeasurements),
        new("Update UnitsOfMeasurements", FSHAction.Update, FSHResource.UnitsOfMeasurements),
        new("Delete UnitsOfMeasurements", FSHAction.Delete, FSHResource.UnitsOfMeasurements),
        new("Search UnitsOfMeasurementsConversion", FSHAction.Search, FSHResource.UnitsOfMeasurementsConversion, IsBasic: true),
        new("View UnitsOfMeasurementsConversion", FSHAction.View, FSHResource.UnitsOfMeasurementsConversion, IsBasic: true),
        new("Create UnitsOfMeasurementsConversion", FSHAction.Create, FSHResource.UnitsOfMeasurementsConversion),
        new("Update UnitsOfMeasurementsConversion", FSHAction.Update, FSHResource.UnitsOfMeasurementsConversion),
        new("Delete UnitsOfMeasurementsConversion", FSHAction.Delete, FSHResource.UnitsOfMeasurementsConversion),
        new("Search Suppliers", FSHAction.Search, FSHResource.Suppliers, IsBasic: true),
        new("View Suppliers", FSHAction.View, FSHResource.Suppliers, IsBasic: true),
        new("Create Suppliers", FSHAction.Create, FSHResource.Suppliers),
        new("Update Suppliers", FSHAction.Update, FSHResource.Suppliers),
        new("Delete Suppliers", FSHAction.Delete, FSHResource.Suppliers),
        new("View Tenants", FSHAction.View, FSHResource.Tenants, IsRoot: true),
        new("Create Tenants", FSHAction.Create, FSHResource.Tenants, IsRoot: true),
        new("Update Tenants", FSHAction.Update, FSHResource.Tenants, IsRoot: true),
        new("Upgrade Tenant Subscription", FSHAction.UpgradeSubscription, FSHResource.Tenants, IsRoot: true),
        new("Create Purchase Order Headers", FSHAction.Create, FSHResource.PurchaseOrderHeaders),
        new("Delete Purchase Order Header", FSHAction.Delete,FSHResource.PurchaseOrderHeaders),
        new("Update Purchase Order Header", FSHAction.Update,FSHResource.PurchaseOrderHeaders),
        new("View Purchase Order Header", FSHAction.View, FSHResource.PurchaseOrderHeaders),

        new("Create Purchase Order", FSHAction.Create, FSHResource.PurchaseOrder),
        new("Delete Purchase Order", FSHAction.Delete, FSHResource.PurchaseOrder),
        new("Update Purchase Order", FSHAction.Update, FSHResource.PurchaseOrder),
        new("View Purchase Order", FSHAction.View, FSHResource.PurchaseOrder)
    };

    public static IReadOnlyList<FSHPermission> All { get; } = new ReadOnlyCollection<FSHPermission>(_all);
    public static IReadOnlyList<FSHPermission> Root { get; } = new ReadOnlyCollection<FSHPermission>(_all.Where(p => p.IsRoot).ToArray());
    public static IReadOnlyList<FSHPermission> Admin { get; } = new ReadOnlyCollection<FSHPermission>(_all.Where(p => !p.IsRoot).ToArray());
    public static IReadOnlyList<FSHPermission> Basic { get; } = new ReadOnlyCollection<FSHPermission>(_all.Where(p => p.IsBasic).ToArray());

}

public record FSHPermission(string Description, string Action, string Resource, bool IsBasic = false, bool IsRoot = false)
{
    public string Name => NameFor(Action, Resource);
    public static string NameFor(string action, string resource) => $"Permissions.{resource}.{action}";
}
