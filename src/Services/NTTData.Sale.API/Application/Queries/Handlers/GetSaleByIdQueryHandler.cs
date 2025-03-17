using MediatR;
using NTTData.Sale.API.Application.DTO;
using NTTData.Sale.API.Application.DTO.Response;
using NTTData.Sale.Domain.Repositories;

namespace NTTData.Sale.API.Application.Queries.Handlers
{
    public class GetSaleByIdQueryHandler : IRequestHandler<GetSaleByIdQuery, SaleResponseDTO>
    {
        private readonly ISaleRepository _saleRepository;

        public GetSaleByIdQueryHandler(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public async Task<SaleResponseDTO> Handle(GetSaleByIdQuery request, CancellationToken cancellationToken)
        {
            var sale = await _saleRepository.GetByIdAsync(request.Id);

            return MapToSaleDTO(sale)!;
        }

        private SaleResponseDTO? MapToSaleDTO(Domain.Sales.Sale? sale)
        {
            if(sale is null)
                return null;

            var saleDTO = new SaleResponseDTO
            {
                Id = sale.Id,
                Status = sale.Status.ToString(),
                TotalSaleAmount = sale.TotalSaleAmount,
                Branch = sale.Branch,
                Number = sale.Number,
                CreatedAt = sale.CreatedAt,
                ProductItems = new List<ProductSaleItemResponseDTO>(),
                Customer = new CustomerDTO { Email = sale.Customer.Email, FullName = sale.Customer.FullName},                
            };

            foreach (var productItem in sale.ProductItems)
            {
                var productDto = new ProductSaleItemResponseDTO
                {
                    Discount = productItem.Discount,
                    ProductName = productItem.ProductName,
                    Quantity = productItem.Quantity,
                    Status = productItem.Status.ToString(),
                    TotalAmount = productItem.TotalAmount,
                    UnitPrice = productItem.UnitPrice,
                    Id = productItem.Id,
                    SaleId = productItem.SaleId
                };

                saleDTO.ProductItems.Add(productDto);
            }

            return saleDTO;
        }
    }
}
