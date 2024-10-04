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

namespace Implementation.UseCases.Commands.TypeLikes
{
    public class EfAddTypeLikeCommand : EfUseCase, IAddTypeLikeCommand
    {
        private AddTypeLikeDtoValidator _validator;
        public EfAddTypeLikeCommand(AspContext context,AddTypeLikeDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 5;

        public string Name => "TypeLikesAdd";

        public void Execute(AddTypeLikeDto data)
        {
            _validator.ValidateAndThrow(data);

            TypeLike typelike = new TypeLike
            {
                Name= data.Name,
                Photo= data.Photo?? "like.png"
            };
            if (data.Photo != null)
            {
                var tempFile = Path.Combine("wwwroot", "temp", data.Photo);
                var destinationFile = Path.Combine("wwwroot", "typelikes", data.Photo);
                System.IO.File.Move(tempFile, destinationFile);
            }

            Context.TypeLikes.Add(typelike);
            Context.SaveChanges();

        }

        
    }
}
