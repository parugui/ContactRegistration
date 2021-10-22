using FluentValidation;

namespace ContactsRegistration.Domain.Models.Entities.Validator
{
    /// <summary>
    /// Validation Class for LegalPerson
    /// </summary>
    internal class LegalPersonValidator: AbstractValidator<LegalPerson>
    {
        public LegalPersonValidator()
        {
            RuleFor(i => i.CompanyName)
                .NotNull()
                    .WithErrorCode(ErrorHelper.ErrorNullOrEmpty.ErrorCode)
                    .WithMessage("The Company Name cannot be null");

            RuleFor(i => i.CNPJ)
                .IsValidCNPJ()
                    .WithErrorCode(ErrorHelper.ErrorInvalidCNPJ.ErrorCode)
                    .WithMessage(ErrorHelper.ErrorInvalidCNPJ.Description);
        }
    }
}
