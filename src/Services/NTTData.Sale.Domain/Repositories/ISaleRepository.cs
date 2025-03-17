using NTTData.Core.Data;
using NTTData.Core.DomainObjects;

namespace NTTData.Sale.Domain.Repositories
{
    public interface ISaleRepository : IDisposable
    {
        IUnitOfWork UnitOfWork { get; }
        Task<Sales.Sale?> GetByIdAsync(Guid id);
        void Add(Sales.Sale sale);
        void Update(Sales.Sale sale);
    }
}
