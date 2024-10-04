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
    public class FavoriteBaseValidator<T> : AbstractValidator<T>
        where T : BaseFavoritesDto
    {
        public FavoriteBaseValidator(AspContext ctx)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.UserId).Must(x => ctx.Users.Any(u => u.Id == x))
                .WithMessage("Tag id must exists").NotEmpty();
            RuleFor(x => x.PostId).Must(x => ctx.Posts.Any(u => u.Id == x))
                .WithMessage("Post id must exists").NotEmpty();

        }
    }
}
