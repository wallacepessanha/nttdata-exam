using NTTData.Core.CommunicationResponse;
using NTTData.Sale.Domain.Enums;

namespace NTTData.Sale.API.Application.DTO
{
    public class SaleDTO
    {        
        public int Number { get; set; }
        public decimal TotalSaleAmount { get; set; }
        public CustomerDTO? Customer { get; set; }
        public List<ProductSaleItemDTO>? ProductItems { get; set; }
        public DateTime CreatedAt { get; set; }
        public SaleStatus Status { get; set; }
        public string? Branch { get; set; }
    }
}
