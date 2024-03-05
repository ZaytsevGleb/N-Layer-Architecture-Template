namespace Shop.Services.Catalog.BusinessLogic.Abstractions;

public interface IService
{
    Task<object> Create(CancellationToken ct);
}