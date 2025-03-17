using NTTData.Core.Messages;
using NTTData.Sale.API.Application.DTO;
using NTTData.Sale.API.Application.Validations;

namespace NTTData.Sale.API.Application.Commands
{
    public class SaleCreatedCommand : Command
    {
        public int SaleNumber { get; set; }        
        public CustomerDTO? Customer { get; set; }
        public List<ProductSaleItemDTO>? Products { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? SaleBranch { get; set; }
        public decimal TotalSaleAmount { get; set; }

        public override bool EhValido()
        {
            ValidationResult = new SaleCreatedValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
