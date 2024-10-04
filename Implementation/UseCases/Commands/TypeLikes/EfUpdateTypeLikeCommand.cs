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
    public class EfUpdateTypeLikeCommand : EfUseCase, IUpdateTypeLikeCommand
    {
        public EfUpdateTypeLikeCommand(AspContext context,UpdateTypeLikeDtoValidator validator) : base(context)
        {
            _validator = validator;
        }
        private UpdateTypeLikeDtoValidator _validator;
        public int Id => 8;

        public string Name => "UpdateTypeLike";

        public void Execute(UpdateTypeLikeDto data)
        {
            

            _validator.ValidateAndThrow(data);
            TypeLike typelike = Context.TypeLikes.First(x => x.Id == data.Id);
            typelike.Name = data.Name;
            typelike.Photo = data.Photo?? "like.png";

            if (data.Photo != null)
            {
                var tempFile = Path.Combine("wwwroot", "temp", data.Photo);
                var destinationFile = Path.Combine("wwwroot", "typelikes", data.Photo);
                System.IO.File.Move(tempFile, destinationFile);
            }
            Context.SaveChanges();
        }
    }
}
