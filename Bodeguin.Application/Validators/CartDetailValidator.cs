using Bodeguin.Domain.Entity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bodeguin.Application.Validators
{
    public class CartDetailValidator : AbstractValidator<Detail>
    {
        public CartDetailValidator()
        {
            RuleFor(d => d.VoucherId)
                .NotNull();
        }
    }
}
