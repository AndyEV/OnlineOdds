using FluentValidation;
using odd.web.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace odd.web.Services.Validations
{
    public class OddDtoValidator : AbstractValidator<CreateOdd>
    {
        public OddDtoValidator()
        {
                RuleFor(x => x.HomeOdd).GreaterThan(0).WithMessage("Home Team Odd must be > 0");
                RuleFor(x => x.DrawOdd).GreaterThan(0).WithMessage("Draw Odd must be > 0");
                RuleFor(x => x.AwayOdd).GreaterThan(0).WithMessage("Away Team Odd must be > 0");

        }
    }

    public class OddUpdateDtoValidator : AbstractValidator<UpdateOdd>
    {
        public OddUpdateDtoValidator()
        {
            RuleFor(x => x.HomeOdd).GreaterThan(0).WithMessage("Home Team Odd must be > 0");
            RuleFor(x => x.DrawOdd).GreaterThan(0).WithMessage("Draw Odd must be > 0");
            RuleFor(x => x.AwayOdd).GreaterThan(0).WithMessage("Away Team Odd must be > 0");

        }
    }

    public class DeleteOddValidations : AbstractValidator<DeleteOdd>
    {
        public DeleteOddValidations()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Select Odd to delete");
        }
    }
}
    

