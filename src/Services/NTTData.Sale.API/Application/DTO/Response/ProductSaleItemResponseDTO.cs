using NTTData.Core.CommunicationResponse;
using NTTData.Sale.Domain.Enums;

namespace NTTData.Sale.API.Application.DTO.Response
{
    public class ProductSaleItemResponseDTO : BaseDTO
    {
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string? ProductName { get; set; }
        public string? Status { get; set; }
        public DateTime? CancelledDate { get; private set; }
        public decimal TotalAmount { get; set; }
        public decimal Discount { get; set; }
        public Guid SaleId { get; set; }
    }
}
