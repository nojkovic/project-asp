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
    public class UpdateTypeLikeDtoValidator : TypeLikeBaseValidator<UpdateTypeLikeDto>
    {
        public UpdateTypeLikeDtoValidator(AspContext ctx) : base(ctx)
        {
            RuleFor(x => x.Id).NotEmpty()
                              .WithMessage("Id is required.")
                              .Must(x => ctx.TypeLikes.Any(c => c.Id == x))
                              .WithMessage("Type like id not exist");
        }
    }
}
