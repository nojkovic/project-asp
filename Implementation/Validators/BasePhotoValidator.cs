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
    public class BasePhotoValidator<T> : AbstractValidator<T>
        where T : BasePhotosDto
    {
        public BasePhotoValidator(AspContext ctx)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.PostId)
                .NotEmpty().WithMessage("Post is required.")
                .Must(x => ctx.Posts.Any(c => c.Id == x))
                .WithMessage(" PostId doesn't exist.");
            RuleFor(x => x.ImagePath).NotEmpty()
                        .WithMessage("At least one image is required.")
                        .DependentRules(() =>
                        {
                            RuleFor(x => x.ImagePath).Must((x, fileName) =>
                            {
                                var path = Path.Combine("wwwroot", "temp", fileName);

                                var exists = Path.Exists(path);

                                return exists;
                            }).WithMessage("File doesn't exist.");
                        });
        }

    }
}

