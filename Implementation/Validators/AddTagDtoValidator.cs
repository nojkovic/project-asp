using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;
using DataAccess;

namespace Implementation.Validators
{
    public class AddTagDtoValidator : TagBaseValidator<AddTagDto>
    {
        public AddTagDtoValidator(AspContext ctx) : base(ctx)
        {
        }
    }
}
