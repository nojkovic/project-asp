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
    public class UpdateCommentValidatorDto : BaseCommentValidator<UpdateCommentDto>
    {
        public UpdateCommentValidatorDto(AspContext ctx) : base(ctx)
        {
            RuleFor(x => x.Id).Must(x => ctx.Comments.Any(u => u.Id == x))
                .WithMessage("Id must exists");
        }
    }
}
