using FluentValidation;
using odd.web.DTOs.TeamDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace odd.web.Services.Validations
{
    public class TeamValidator : AbstractValidator<CreateTeam>
    {

    }

    public class CreateTeamValidations : AbstractValidator<CreateTeam>
    {
        public CreateTeamValidations()
        {
            RuleFor(x => x.HomeTeam).Length(3, 50).WithMessage("Home team is Required");
            RuleFor(x => x.AwayTeam).Length(3, 50).WithMessage("Away Team Is Required");
        }
    }

    public class UpdateTeamValidations : AbstractValidator<UpdateTeam>
    {
        public UpdateTeamValidations()
        {
            RuleFor(x => x.HomeTeam).Length(3, 50).WithMessage("Home team is Required");
            RuleFor(x => x.AwayTeam).Length(3, 50).WithMessage("Away Team Is Required");
        }
    }

    public class DeleteTeamValidations : AbstractValidator<DeleteTeam>
    {
        public DeleteTeamValidations()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Select Team Pair to delete");
        }
    }
}
