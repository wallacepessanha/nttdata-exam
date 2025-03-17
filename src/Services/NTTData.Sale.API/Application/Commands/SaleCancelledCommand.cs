using NTTData.Core.Messages;
using NTTData.Sale.API.Application.DTO;
using NTTData.Sale.API.Application.Validations;

namespace NTTData.Sale.API.Application.Commands
{
    public class SaleCancelledCommand : Command
    {
        public Guid SaleId { get; set; } 
        public DateTime? CancelledDate { get; set; }

        public override bool EhValido()
        {
            ValidationResult = new SaleCancelledValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
