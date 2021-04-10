using AltHealth.Data.Gateways.Repositories.Interfaces;

namespace AltHealth.Data.Gateways.Repositories.Wrapper
{
    public interface IRepositoryWrapper
    {
        IClientInfoRepository ClientInfo { get; }
        IInvoiceInfoRepository InvoiceInfo { get; }
        IInvoiceItemsRepository InvoiceItems { get; }
        IReferenceRepository Reference { get; }
        ISupplimentRepository Suppliment { get; }
        ISupplierRepository Supplier { get; }
    }
}
