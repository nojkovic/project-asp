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
    public class UserBaseValidator<T> : AbstractValidator<T>
        where T :BaseUserDto
    {
        public UserBaseValidator(AspContext ctx)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Email)
                .EmailAddress()
                .Must(x => !ctx.Users.Any(u => u.Email == x))
                .WithMessage("Email is already in use.");
            RuleFor(x => x.Name).Matches("^[A-Z][a-zA-Z]{2,14}$")
                .WithMessage("The first character or letter must be uppercase, the minimum length is 3 and the maximum is 15 characters.");
            RuleFor(x => x.LastName).Matches("^[A-Z][a-zA-Z]{2,14}$")
                .WithMessage("The first character or letter must be uppercase, the minimum length is 3 and the maximum is 15 characters.");
            RuleFor(x => x.Password).Matches("^(?=.*[A-Z])(?=.*[0-9])(?=.*[^A-Za-z0-9]).{8,}$")
                .WithMessage("The password must contain at least 8 characters and must contain at least one capital letter, one number and one special character.");
            RuleFor(x => x.Username)
                .Matches("^[a-zA-Z][a-zA-Z0-9]{2,13}$")
                .WithMessage("The first character must be a letter (either uppercase or lowercase), After the first letter, 2 to 13 characters are allowed which can be letters or numbers.")
                .Must(x => !ctx.Users.Any(u => u.Username == x))
                .WithMessage("Username is already in use.");
           
            RuleFor(x => x.Photo).Must((x, fileName) =>
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
    }
}
