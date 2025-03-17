using FluentValidation.Results;
using MediatR;
using NTTData.Core.Mediator;
using NTTData.Core.Messages;
using NTTData.Sale.API.Application.Events;
using NTTData.Sale.Domain.Enums;
using NTTData.Sale.Domain.Repositories;

namespace NTTData.Sale.API.Application.Commands.Handlers
{
    public class SaleCancelledCommandHandler : CommandHandler,
        IRequestHandler<SaleCancelledCommand, ValidationResult>
    {
        private readonly ISaleRepository  _saleRepository;

        public SaleCancelledCommandHandler(ISaleRepository saleRepository)
        {            
            _saleRepository = saleRepository;
        }

        public async Task<ValidationResult> Handle(SaleCancelledCommand request, CancellationToken cancellationToken)
        {
            if (!request.EhValido()) return request.ValidationResult;

            var sale = await _saleRepository.GetByIdAsync(request.SaleId);

            Validate(sale);

            if (AnyError())
                return ValidationResult;

            sale.SetAsCancelled(request.CancelledDate);

            sale.AddEvent(new SaleCancelledEvent(sale.Id, sale.Customer.Email, sale.Number));

            _saleRepository.Update(sale);            

            return await SaveAsync(_saleRepository.UnitOfWork);
        }

        private void Validate(Domain.Sales.Sale? sale)
        {
            if (sale is null)
            {
                AddError("Purchase not found.");
            }

            if (sale is not null && sale.Status.Equals(SaleStatus.Cancelled))
            {
                AddError("The informed purchase is already cancelled");
            }
        }
    }
}

