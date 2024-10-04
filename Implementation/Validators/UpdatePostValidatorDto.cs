using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;
using DataAccess;

namespace Implementation.Validators
{
    public class UpdatePostValidatorDto : BasePostValidator<UpdatePostDto>
    {
        public UpdatePostValidatorDto(AspContext ctx) : base(ctx)
        {
        }
    }
}
