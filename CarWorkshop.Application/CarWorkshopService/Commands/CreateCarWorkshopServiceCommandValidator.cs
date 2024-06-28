using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.CarWorkshopService.Commands
{
    public class CreateCarWorkshopServiceCommandValidator : AbstractValidator<CreateCarWorkshopServiceCommand>
    {
        public CreateCarWorkshopServiceCommandValidator()
        {
            RuleFor(a => a.Cost).NotEmpty().NotNull();
            RuleFor(a => a.Description).NotEmpty().NotNull();
            RuleFor(a => a.CarWorkshopEncoededName).NotEmpty().NotNull();
        }
    }
}
