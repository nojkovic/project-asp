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
    public class BaseCommentValidator<T>:AbstractValidator<T>
        where T : AddCommentDto
    {
        AspContext context;
        public BaseCommentValidator(AspContext ctx) 
        {
            context = ctx;
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Text).NotNull()
                                .WithMessage("Comment is required.")
                                .MinimumLength(3)
                                .WithMessage("Min number of characters is 3.");


            RuleFor(x => x.ParentId).Must(CommentExistsWhenNotNull)
                                    .WithMessage("Parent id doesn't exist.");

            RuleFor(x => x.ChildIds).Must(AllChildrenExist).WithMessage("Not all child categories exist in database.");

        }
        private bool AllChildrenExist(IEnumerable<int> ids)
        {
            if (ids == null || !ids.Any())
            {
                return true;
            }

            int brojIzBaze = context.Comments.Count(x => ids.Contains(x.Id));
            return brojIzBaze == ids.Count();

        }

        private bool CommentExistsWhenNotNull(int? parentId)
        {
            if (!parentId.HasValue)
            {
                return true;
            }

            return context.Comments.Any(x => x.Id == parentId);
        }
    }
}
