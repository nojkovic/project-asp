using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;
using DataAccess;
using FluentValidation;

namespace Implementation.Validators
{
    public class DeleteTagDtoValidator : AbstractValidator<BaseDTO>
    {
        public DeleteTagDtoValidator(AspContext ctx)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Id).Must(x => ctx.Tags.Any(u => u.Id == x))
                .WithMessage("Id must exists");
        }
    }
}
