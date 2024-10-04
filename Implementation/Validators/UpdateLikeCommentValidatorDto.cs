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
    public class UpdateLikeCommentValidatorDto : BaseLikeCommentValidator<UpdateLikeCommentDto>
    {
        public UpdateLikeCommentValidatorDto(AspContext ctx) : base(ctx)
        {
            RuleFor(x => x.Id).Must(x => ctx.LikeComments.Any(u => u.Id == x))
               .WithMessage("Id must exists");
        }
    }
}
