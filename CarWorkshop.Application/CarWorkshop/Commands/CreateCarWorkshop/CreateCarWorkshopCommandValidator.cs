using CarWorkshop.Application.CarWorkshop;
using CarWorkshop.Domain.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.CarWorkshop.Commands.CreateCarWorkshop
{
    public class CreateCarWorkshopCommandValidator : AbstractValidator<CreateCarWorkshopCommand>
    {
        public CreateCarWorkshopCommandValidator(ICarWorkshopRepository repository)
        {
            RuleFor(a => a.Name)
                .NotEmpty()
                .MinimumLength(2).WithMessage("Minimum 2 znaki.")
                .MaximumLength(20).WithMessage("Max 20 znaków.")
                .Custom((value, context) =>
                {
                    var existingCarWorkshop = repository.GetByName(value).Result;
                    if (existingCarWorkshop != null)
                    {
                        context.AddFailure($"{value} nie jest nazwą unikalną dla warsztatu.");
                    }
                });

            RuleFor(a => a.Description)
                .NotEmpty().WithMessage("Proszę wprowadzić opis!");

            RuleFor(a => a.PhoneNumber)
                .MinimumLength(8)
                .MaximumLength(12);
        }
    }
}
