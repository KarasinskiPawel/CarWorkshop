using CarWorkshop.Domain.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.CarWorkshop.Commands.EditCarWorkshop
{
    public class EditCarWorkshopCommandValidator : AbstractValidator<EditCarWorkshopCommand>
    {
        public EditCarWorkshopCommandValidator(ICarWorkshopRepository repository)
        {
            RuleFor(a => a.Description)
                .NotEmpty().WithMessage("Proszę wprowadzić opis!");

            RuleFor(a => a.PhoneNumber)
                .MinimumLength(8)
                .MaximumLength(12);
        }
    }
}
