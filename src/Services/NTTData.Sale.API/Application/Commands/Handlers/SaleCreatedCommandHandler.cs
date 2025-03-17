using FluentValidation.Results;
using MediatR;
using NTTData.Core.Mediator;
using NTTData.Core.Messages;
using NTTData.Sale.API.Application.DTO;
using NTTData.Sale.API.Application.Events;
using NTTData.Sale.Domain.Repositories;
using NTTData.Sale.Domain.Sales;

namespace NTTData.Sale.API.Application.Commands.Handlers
{
    public class SaleCreatedCommandHandler : CommandHandler,
        IRequestHandler<SaleCreatedCommand, ValidationResult>
    {
        private readonly ISaleRepository _saleRepository;

        public SaleCreatedCommandHandler(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public async Task<ValidationResult> Handle(SaleCreatedCommand request, CancellationToken cancellationToken)
        {
            if (!request.EhValido()) return request.ValidationResult;

            var sale = MapToSale(request);

            sale.ProductItems.ForEach(ValidadeProduct);     
            
            if(AnyError())
                return ValidationResult;

            if(!ValidateSale(sale))
                return ValidationResult;

            sale.SetAsNotCancelled();

            sale.AddEvent(new SaleCreatedEvent(sale.Id, sale.Customer.Email, sale.Number));

            _saleRepository.Add(sale);            
            
            return await SaveAsync(_saleRepository.UnitOfWork);

        }        
        private void ValidadeProduct(ProductSaleItem product)
        {
            if(product.Quantity > 20)
            {
                AddError("It's not possible to sell above 20 identical items.");
            }

            if(product.Quantity < 4)
            {
                AddError("Purchases below 4 items cannot have a discount");
            }

            if (string.IsNullOrEmpty(product.ProductName))
            {
                AddError("Product Name needs to be informed.");
            }
        }

        private bool ValidateSale(Domain.Sales.Sale sale)
        {
            var saleTotalAmount = sale.TotalSaleAmount;

            sale.CalculateTotalSaleAmount();

            if (sale.TotalSaleAmount != saleTotalAmount)
            {
                AddError("Total sales value different from the total with discounts");
                return false;
            }           

            return true;
        }

        private Domain.Sales.Sale MapToSale(SaleCreatedCommand saleCreatedCommand)
        {
            var customer = new Customer(saleCreatedCommand.Customer!.FullName!, saleCreatedCommand.Customer.Email!);

            return new Domain.Sales.Sale(customer, saleCreatedCommand.Products!.Select(ProductSaleItemDTO.ParaPedidoItem).ToList(), 
                saleCreatedCommand.SaleNumber, saleCreatedCommand.SaleBranch, saleCreatedCommand.TotalSaleAmount);
        }
    }
}
