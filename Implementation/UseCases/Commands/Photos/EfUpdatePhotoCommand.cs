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
using Microsoft.EntityFrameworkCore.Update;

namespace Implementation.UseCases.Commands.Photos
{
    public class EfUpdatePhotoCommand : EfUseCase, IUpdatePhotoCommand
    {
        private UpdatePhotoValidatorDto _validator;
        public EfUpdatePhotoCommand(AspContext context, UpdatePhotoValidatorDto validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 38;

        public string Name => "UpdatePhoto";

        public void Execute(UpdatePhotoDto data)
        {
           
            _validator.ValidateAndThrow(data);

           
            var existingPhoto = Context.Photos.FirstOrDefault(p => p.PostId == data.PostId);

            if (existingPhoto != null)
            {
                
                var oldFilePath = Path.Combine("wwwroot", "posts", existingPhoto.Path);
                if (System.IO.File.Exists(oldFilePath))
                {
                    System.IO.File.Delete(oldFilePath);
                }

                Context.Photos.Remove(existingPhoto);
            }

            var tempFile = Path.Combine("wwwroot", "temp", data.ImagePath);
            var destinationFile = Path.Combine("wwwroot", "posts", data.ImagePath);
            System.IO.File.Move(tempFile, destinationFile);

            
            Photo newPhoto = new Photo
            {
                PostId = data.PostId,
                Path = data.ImagePath,
            };

            Context.Photos.Add(newPhoto);

            Context.SaveChanges();


        }
    }
}
