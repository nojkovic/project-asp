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
    public class EfDeleteFavoriteCommand : EfUseCase, IDeleteFavoriteCommand
    {
        private DeleteFavoriteValidatorDto _validator;
        public EfDeleteFavoriteCommand(AspContext context, DeleteFavoriteValidatorDto validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 34;

        public string Name => "DeleteFavorite";

        public void Execute(BaseFavoritesDto data)
        {
            _validator.ValidateAndThrow(data);
            Favorite favorite = Context.Favorites.FirstOrDefault(x => x.UserId == data.UserId && x.PostId == data.PostId);


            Context.Favorites.Remove(favorite);

            Context.SaveChanges();
        }
    }
}
