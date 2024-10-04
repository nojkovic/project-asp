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
    public class BasePostValidator<T>:AbstractValidator<T>
        where T : BasePostDto
    {
        public BasePostValidator(AspContext ctx) 
        {
            RuleFor(x => x.UserId).Must(x => ctx.Users.Any(u => u.Id == x))
                .WithMessage("User Id must exists");
            
        }
    }
}
