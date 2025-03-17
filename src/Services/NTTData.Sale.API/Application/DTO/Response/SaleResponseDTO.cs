using NTTData.Core.CommunicationResponse;
using NTTData.Sale.Domain.Enums;

namespace NTTData.Sale.API.Application.DTO.Response
{
    public class SaleResponseDTO : BaseDTO
    {
        public int Number { get; set; }
        public decimal TotalSaleAmount { get; set; }
        public CustomerDTO? Customer { get; set; }
        public List<ProductSaleItemResponseDTO>? ProductItems { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? Status { get; set; }
        public string? Branch { get; set; }
        public DateTime? CancelledDate { get; set; }
    }
}
