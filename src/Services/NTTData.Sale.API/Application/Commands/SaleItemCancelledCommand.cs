using NTTData.Core.Messages;
using NTTData.Sale.API.Application.Validations;

namespace NTTData.Sale.API.Application.Commands
{
    public class SaleItemCancelledCommand : Command
    {
        public Guid SaleId { get; set; }
        public Guid ProductItemId { get; set; }
        public DateTime? CancelledDate { get; set; }


        public override bool EhValido()
        {
            ValidationResult = new SaleItemCancelledValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
