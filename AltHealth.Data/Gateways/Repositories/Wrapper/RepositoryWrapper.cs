using AltHealth.Data.Gateways.Repositories.Interfaces;

namespace AltHealth.Data.Gateways.Repositories.Wrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly IDbFactory _dbFactory;

        private IClientInfoRepository clientInfoRepository;
        private IInvoiceInfoRepository invoiceInfoRepository;
        private IInvoiceItemsRepository invoiceItemsRepository;
        private IReferenceRepository referenceRepository;
        private ISupplimentRepository supplimentRepository;
        private ISupplierRepository supplierRepository;
        public RepositoryWrapper(IDbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }
        public IClientInfoRepository ClientInfo => clientInfoRepository = clientInfoRepository ?? new ClientInfoRepository(_dbFactory);

        public IInvoiceInfoRepository InvoiceInfo => invoiceInfoRepository = invoiceInfoRepository ?? new InvoiceInfoRepository(_dbFactory);

        public IInvoiceItemsRepository InvoiceItems => invoiceItemsRepository = invoiceItemsRepository ?? new InvoiceItemsRepository(_dbFactory);

        public IReferenceRepository Reference => referenceRepository = referenceRepository ?? new ReferenceRepository(_dbFactory);

        public ISupplimentRepository Suppliment => supplimentRepository = supplimentRepository ?? new SupplimentRepository(_dbFactory);

        public ISupplierRepository Supplier => supplierRepository = supplierRepository ?? new SupplierRepository(_dbFactory);
    }
}
