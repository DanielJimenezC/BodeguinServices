using Bodeguin.Domain.Entity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bodeguin.Application.Validators
{
    public class InventoryValidator : AbstractValidator<Inventory>
    {
        public InventoryValidator() { }
    }
}
