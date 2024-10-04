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
    public class BaseLikeCommentValidator<T> : AbstractValidator<T>
        where T : BaseLikeCommentDto
    {
        public BaseLikeCommentValidator(AspContext ctx) 
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.UserId).Must(x => ctx.Users.Any(u => u.Id == x))
                .WithMessage("User Id must exists");

            RuleFor(x => x.CommentId).Must(x => ctx.Comments.Any(u => u.Id == x))
                .WithMessage("Comment Id must exists");
        }
    }
}
