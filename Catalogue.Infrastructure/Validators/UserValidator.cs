using Catalogue.Core.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogue.Infrastructure.Validators
{
    public class UserValidator : AbstractValidator<UserDTO>
    {
        public UserValidator()
        {
            RuleFor(user => user.Username)
                .NotNull();

            RuleFor(user => user.Password)
                .NotNull();
        }
    }
}
