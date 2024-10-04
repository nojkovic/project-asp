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
    public class UpdateLikePostDtoValidator : LikePostBaseValidator<UpdateLikePostDto>
    {
        public UpdateLikePostDtoValidator(AspContext ctx) : base(ctx)
        {
            RuleFor(x => x.Id).NotEmpty()
                              .WithMessage("Id is required.")
                              .Must(x => ctx.LikePosts.Any(c => c.Id == x))
                              .WithMessage("Like post id not exist");
        }
    }
}
