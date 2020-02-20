using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace PropellerheadCI.Business.Models.Validations
{
    public class CustomerValidations : AbstractValidator<Customer>
    {
        public CustomerValidations()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("The field {PropertyName} is needed")
                .Length(5, 200).WithMessage("The field {PropertyName} must have between {MinLength} and {MaxLength} characters");

            RuleFor(c => c.Surname)
                .NotEmpty().WithMessage("The field {PropertyName} is needed")
                .Length(5, 200).WithMessage("The field {PropertyName} must have between {MinLength} and {MaxLength} characters");

            RuleFor(c => c.Phone)
                .NotEmpty().WithMessage("The field {PropertyName} is needed")
                .Length(9, 20).WithMessage("The field {PropertyName} must have between {MinLength} and {MaxLength} characters");
        }
    }
}
