using FluentValidation;
using NTTData.Sale.API.Application.Commands;

namespace NTTData.Sale.API.Application.Validations
{    
    public class SaleCreatedValidation : AbstractValidator<SaleCreatedCommand>
    {
        public SaleCreatedValidation()
        {
            RuleFor(c => c.CreatedAt)
                .LessThanOrEqualTo(DateTime.Now)
                .WithMessage("The sale date must not be greater than today");

            RuleFor(c => c.Products)
                .NotNull()
                .WithMessage("Products needs to be informed.");

            RuleFor(c => c.Products!.Count)
                    .GreaterThan(0)
                    .WithMessage("The sale needs at least 1 item.");

            RuleFor(c => c.SaleNumber)
                .GreaterThan(0)
                .WithMessage("Sale number invalid.");

            RuleFor(c => c.SaleBranch)
                .NotEmpty()
                .WithMessage("Sale Branch needs to be informed.");

            RuleFor(c => c.Customer)
                .NotNull()
                .WithMessage("Customer needs to be informed.");

            RuleFor(c => c.Customer!.Email)
                .NotEmpty()
                .WithMessage("Customer e-mail needs to be informed.");

            RuleFor(c => c.Customer!.FullName)
                .NotEmpty()
                .WithMessage("Customer fullName needs to be informed.");         

        }
    }
}
