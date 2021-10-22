using FluentValidation;

namespace ContactsRegistration.Domain.Models.Entities.Validator
{
    /// <summary>
    /// Validation class for the NaturalPerson 
    /// </summary>
    internal class NaturalPersonValidator: AbstractValidator<NaturalPerson>
    {
        public NaturalPersonValidator()
        {
            RuleFor(i => i.Name)
                .NotEmpty()
                    .WithErrorCode(ErrorHelper.ErrorNullOrEmpty.ErrorCode)
                    .WithMessage("The Name cannot be null.");

            RuleFor(i => i.CPF)
                .IsValidCPF()
                    .WithErrorCode(ErrorHelper.ErrorInvalidCPF.ErrorCode)
                    .WithMessage(ErrorHelper.ErrorInvalidCPF.Description);
        }
    }
}
