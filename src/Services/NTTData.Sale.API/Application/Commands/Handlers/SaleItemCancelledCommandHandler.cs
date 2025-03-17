using FluentValidation.Results;
using MediatR;
using NTTData.Core.Mediator;
using NTTData.Core.Messages;
using NTTData.Sale.API.Application.Events;
using NTTData.Sale.Domain.Enums;
using NTTData.Sale.Domain.Repositories;

namespace NTTData.Sale.API.Application.Commands.Handlers
{
    public class SaleItemCancelledCommandHandler : CommandHandler,
        IRequestHandler<SaleItemCancelledCommand, ValidationResult>
    {
        private readonly ISaleRepository _saleRepository;

        public SaleItemCancelledCommandHandler(ISaleRepository saleRepository)
        {            
            _saleRepository = saleRepository;
        }

        public async Task<ValidationResult> Handle(SaleItemCancelledCommand request, CancellationToken cancellationToken)
        {
            if (!request.EhValido()) return request.ValidationResult;

            var sale = await _saleRepository.GetByIdAsync(request.SaleId);

            if (sale is null)
            {
                AddError("ProductItem not found.");
                return ValidationResult;
            }

            var productItem = sale.ProductItems.FirstOrDefault(x => x.Id == request.ProductItemId);

            if (productItem is null)
            {
                AddError("ProductItem not found.");
                return ValidationResult;
            }

            productItem.SetAsCancelled(request.CancelledDate);

            sale.CalculateTotalSaleAmount();

            sale.AddEvent(new SaleItemCancelledEvent(sale.Id, productItem.Id, sale.Customer.Email, sale.Number));

            _saleRepository.Update(sale);            

            return await SaveAsync(_saleRepository.UnitOfWork);
        }        
    }
}
