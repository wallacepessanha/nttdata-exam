using FluentValidation.Results;
using NTTData.Core.Data;

namespace NTTData.Core.Messages
{
    public abstract class CommandHandler
    {
        protected ValidationResult ValidationResult;

        protected CommandHandler()
        {
            ValidationResult = new ValidationResult();
        }

        protected void AddError(string message)
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, message));
        }

        protected bool AnyError()
        {
            return ValidationResult.Errors.Any();
        }

        protected async Task<ValidationResult> SaveAsync(IUnitOfWork uow)
        {
            if (!await uow.Commit()) AddError("There was an error persisting data.");

            return ValidationResult;
        }
    }
}
