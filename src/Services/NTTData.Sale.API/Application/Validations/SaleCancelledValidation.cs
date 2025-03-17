using FluentValidation;
using NTTData.Sale.API.Application.Commands;

namespace NTTData.Sale.API.Application.Validations
{
    public class SaleCancelledValidation : AbstractValidator<SaleCancelledCommand>
    {
        public SaleCancelledValidation()
        {
            RuleFor(c => c.CancelledDate)
                .NotNull()
                .WithMessage("Cancelled Date needs to be informed.");
            
        }
    }
}
