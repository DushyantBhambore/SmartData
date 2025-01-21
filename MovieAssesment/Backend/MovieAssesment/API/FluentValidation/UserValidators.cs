using Doamin;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.FluentValidation
{
    public class UserValidators :  AbstractValidator<User>
    {
        public UserValidators()
        {
            RuleFor(a => a.FirstName)
                .NotEmpty().WithMessage("FirstName name is required.")
                .Length(3, 15).WithMessage("FirstName name must be between 3 and 15 ");
            RuleFor(a => a.LastName)
               .NotEmpty().WithMessage("LastName name is required.")
               .Length(3, 15).WithMessage("LastName name must be between 3 and 15 ");
            RuleFor(a => a.DateOfBirth).NotEmpty().WithMessage("Date of birth is required.");
            RuleFor(a => a.Email)
                .NotEmpty().WithMessage("Email name is required.")
                .EmailAddress().WithMessage("A valid email address is required.");
        }
    }
}
