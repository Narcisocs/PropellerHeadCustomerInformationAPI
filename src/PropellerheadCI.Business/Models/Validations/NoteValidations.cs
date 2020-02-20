using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace PropellerheadCI.Business.Models.Validations
{
    public class NoteValidations : AbstractValidator<Note>
    {
        public NoteValidations()
        {
            RuleFor(n => n.Message)
                .NotEmpty().WithMessage("The field {PropertyName} is needed")
                .Length(1, 500).WithMessage("The field {PropertyName} must have between {MinLength} and {MaxLength} characters");
        }
    }
}
