using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;
using Application.UseCases.Commands.TypeLikes;
using Application.UseCases.Commands.Users;
using DataAccess;
using Domain;
using FluentValidation;
using Implementation.Validators;
using Microsoft.EntityFrameworkCore;

namespace Implementation.UseCases.Commands.TypeLikes
{
    public class EfDeleteTypeLikeCommand : EfUseCase, IDeleteTypeLikeCommand
    {
        private DeleteTypeLikeDtoValidator _validator;
        public EfDeleteTypeLikeCommand(AspContext context,DeleteTypeLikeDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 6;

        public string Name => "TypeLikeDelete";

        public void Execute(BaseDTO data)
        {
            _validator.ValidateAndThrow(data);
            TypeLike typelike=Context.TypeLikes.Include(x=>x.LikePosts)
                                           .First(c=>c.Id==data.Id);

            var typeLikePost = typelike.LikePosts;
            var filePath = Path.Combine("wwwroot", "typelikes", typelike.Photo);
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
            Context.LikePosts.RemoveRange(typeLikePost);

            Context.TypeLikes.Remove(typelike);
            Context.SaveChanges();
        }
    }
}
