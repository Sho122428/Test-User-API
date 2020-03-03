using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestUser.Model;

namespace TestUser.Validator
{
    public class DataValidator : AbstractValidator<User>
    {
        public DataValidator() {
            RuleFor(a => a.Id).InclusiveBetween(1, 10);
            RuleFor(a => a.FirstName).NotEmpty().WithMessage("Please specify a first name");
            RuleFor(a => a.LastName).NotEmpty().WithMessage("Please specify a last name");
            RuleFor(a => a.DateOfBirth).NotEmpty().WithMessage("Please specify a birthday");
        }        
    }
}
