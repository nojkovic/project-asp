using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;
using Application.UseCases.Commands.Photos;
using DataAccess;
using Domain;
using FluentValidation;
using Implementation.Validators;

namespace Implementation.UseCases.Commands.Photos
{
    public class EfDeletePhotoCommand : EfUseCase, IDeletePhotoCommand
    {
        private DeletePhotoValidatorDto _validator;
        public EfDeletePhotoCommand(AspContext context, DeletePhotoValidatorDto validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 36;

        public string Name => "DeletePhoto";

        public void Execute(PhotoDto data)
        {
            _validator.ValidateAndThrow(data);

            var photos = Context.Photos.Where(p => p.PostId == data.Id).ToList();

            foreach (var photo in photos)
            {
                var filePath = Path.Combine("wwwroot", "posts", photo.Path);
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }

                Context.Photos.Remove(photo);
            }

            Context.SaveChanges();
        }
    }
}
