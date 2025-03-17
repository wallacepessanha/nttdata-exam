using NTTData.Sale.Domain.Sales;

namespace NTTData.Sale.API.Application.DTO
{
    public class ProductSaleItemDTO
    {
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }        
        public string? ProductName { get; set; }

        public static ProductSaleItem ParaPedidoItem(ProductSaleItemDTO productDTO)
        {
            return new ProductSaleItem(productDTO.Quantity, productDTO.UnitPrice,
                productDTO.ProductName);
        }
    }
}
