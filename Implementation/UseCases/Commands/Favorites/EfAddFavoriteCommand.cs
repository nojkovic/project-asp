using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;
using Application.UseCases.Commands.Favorites;
using DataAccess;
using Domain;
using FluentValidation;
using Implementation.Validators;

namespace Implementation.UseCases.Commands.Favorites
{
    public class EfAddFavoriteCommand : EfUseCase, IAddFavoriteCommand
    {
        private AddFavoriteValidatorDto _validator;
        public EfAddFavoriteCommand(AspContext context, AddFavoriteValidatorDto validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 33;

        public string Name => "AddFavorite";

        public void Execute(AddFavoriteDto data)
        {
            _validator.ValidateAndThrow(data);
            Favorite favorite = new Favorite
            {
                UserId = data.UserId,
                PostId = data.PostId
            };

            Context.Favorites.Add(favorite);
            Context.SaveChanges();
        }
    }
}
