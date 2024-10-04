using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;
using DataAccess;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Implementation.Validators
{
    public class AddCommentValidatorDto : BaseCommentValidator<AddCommentDto>

    {
        
        public AddCommentValidatorDto(AspContext ctx) : base(ctx)
        {
        }
    }
}
    

