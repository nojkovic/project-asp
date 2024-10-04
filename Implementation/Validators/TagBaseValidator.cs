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
    public class TagBaseValidator<T> : AbstractValidator<T>
        where T : BaseTagDto
    {
        public TagBaseValidator(AspContext ctx) 
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.Name).MinimumLength(2)
                                .NotEmpty()
                                .MaximumLength(50)
                                .Must(x => !ctx.Tags.Any(u => u.Name == x))
                                .WithMessage("Name is already in use.");



        }
    }
}
