using Bodeguin.Domain.Entity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bodeguin.Application.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(user => user.Name)
                .NotNull()
                .Length(2, 50);

            RuleFor(user => user.FirstLastName)
                .NotNull()
                .Length(2, 50);

            RuleFor(user => user.SecondLastName)
                .NotNull()
                .Length(2, 50);

            RuleFor(user => user.Dni)
                .NotNull()
                .Length(1, 10);

            RuleFor(user => user.Direction)
                .NotNull()
                .Length(1, 200);

            RuleFor(user => user.Email)
                .NotNull()
                .Length(2, 50);

            RuleFor(user => user.Password)
                .NotNull()
                .Length(2, 200);
        }
    }
}
