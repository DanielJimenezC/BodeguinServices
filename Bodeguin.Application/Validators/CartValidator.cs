using Bodeguin.Domain.Entity;
using FluentValidation;

namespace Bodeguin.Application.Validators
{
    public class CartValidator : AbstractValidator<Voucher>
    {
        public CartValidator() { }
    }
}
