using Microsoft.EntityFrameworkCore;
using NTTData.Core.Data;
using NTTData.Core.Mediator;
using NTTData.Sale.Domain.Repositories;

namespace NTTData.Sale.Infra.Data.Repository
{
    public class SaleRepository : ISaleRepository
    {
        private readonly SalesContext _context;
        private readonly IMediatorHandler _mediator;

        public SaleRepository(IMediatorHandler mediator, SalesContext context)
        {            
            _mediator = mediator;
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public void Add(Domain.Sales.Sale sale)
        {
            _context.Sales.AddAsync(sale);            
        }
      
        public async Task<Domain.Sales.Sale?> GetByIdAsync(Guid id)
        {
            return await _context.Sales.Include(x=>x.ProductItems).FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public void Update(Domain.Sales.Sale sale)
        {
            _context.Sales.Update(sale);            
        }
        public void Dispose()
        {
            _context.Dispose();
        }        
    }
}
