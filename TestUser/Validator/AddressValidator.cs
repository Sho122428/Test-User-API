using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestUser.Model;

namespace TestUser.Validator
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator(){
           //RuleFor(a => a.ID).SetValidator(new DataValidator());
        }
    }
}
