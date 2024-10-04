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
    public class LikePostBaseValidator<T> : AbstractValidator<T>
        where T : BaseLikesPostDto
    {
        public LikePostBaseValidator(AspContext ctx) 
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.UserId).Must(x => ctx.Users.Any(u => u.Id == x))
                .WithMessage("User Id must exists");

            RuleFor(x => x.PostId).Must(x => ctx.Posts.Any(u => u.Id == x))
                .WithMessage("Post id must exists");

            RuleFor(x => x.TypeLikeId).Must(x => ctx.TypeLikes.Any(u => u.Id == x))
                .WithMessage("TypeLike id must exists");

        }
    }
}
