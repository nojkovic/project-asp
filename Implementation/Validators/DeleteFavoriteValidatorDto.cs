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
    public class DeleteFavoriteValidatorDto : FavoriteBaseValidator<BaseFavoritesDto>
    {
        public DeleteFavoriteValidatorDto(AspContext ctx) : base(ctx)
        {
        }
    }
}
