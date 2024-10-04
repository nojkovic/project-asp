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
    public class TypeLikeBaseValidator<T> : AbstractValidator<T>
        where T : BaseTypeLikeDto
    {
        public TypeLikeBaseValidator (AspContext ctx)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x=>x.Name).NotEmpty()
                                .MinimumLength(3)
                                .WithMessage("Minimum character is 3")
                                .MaximumLength(30)
                                .WithMessage("Maximum character is 30");
            RuleFor(x => x.Photo).Must(IsValidImageExtension)
                                  .WithMessage("The image must be a JPG or PNG file.")
                                  .Must((x, fileName) =>
                                  {
                                      if (fileName == null)
                                      {
                                          return true; 
                                      }
                                      var path = Path.Combine("wwwroot", "temp", fileName);

                                      var exists = Path.Exists(path);

                                      return exists;
                                  }).WithMessage("File doesn't exist."); 
           

        }

        private bool IsValidImageExtension(string photo)
        {
            if (photo == null)
            {
                return true;
            }

            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
            return allowedExtensions.Any(ext => photo.EndsWith(ext, StringComparison.OrdinalIgnoreCase));
        }
    }
}
