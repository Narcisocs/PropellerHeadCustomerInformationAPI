using FluentValidation;
using PropellerheadCI.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PropellerheadCI.Business.Models.Validations
{
    public class AddressValidations : AbstractValidator<Address>
    {
        public AddressValidations()
        {
            RuleFor(a => a.Street)
                .NotEmpty().WithMessage("The field {PropertyName} is needed")
                .Length(2, 200).WithMessage("The field {PropertyName} must have between {MinLength} and {MaxLength} characters");

            RuleFor(a => a.Neighborhood)
                .NotEmpty().WithMessage("The field {PropertyName} is needed")
                .Length(2, 100).WithMessage("The field {PropertyName} must have between {MinLength} and {MaxLength} characters");

            RuleFor(a => a.ZipCode)
                .NotEmpty().WithMessage("The field {PropertyName} is needed")
                .Length(8).WithMessage("The field {PropertyName} must have {MaxLength} characters");

            RuleFor(a => a.City)
                .NotEmpty().WithMessage("The field {PropertyName} is needed")
                .Length(3, 100).WithMessage("The field {PropertyName} must have between {MinLength} and {MaxLength} characters");

            RuleFor(a => a.State)
                .NotEmpty().WithMessage("The field {PropertyName} is needed")
                .Length(2, 50).WithMessage("The field {PropertyName} must have between {MinLength} and {MaxLength} characters");

            RuleFor(a => a.Street)
                .NotEmpty().WithMessage("The field {PropertyName} is needed")
                .Length(1, 50).WithMessage("The field {PropertyName} must have between {MinLength} and {MaxLength} characters");
        }
    }
}
