using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;
using Application.UseCases.Commands.Photos;
using DataAccess;
using Domain;
using FluentValidation;
using Implementation.Validators;
using Microsoft.VisualBasic.FileIO;

namespace Implementation.UseCases.Commands.Photos
{
    public class EfAddPhotoCommand : EfUseCase, IAddPhotoCommand
    {
        private AddPhotoValidatorDto _validator;
        public EfAddPhotoCommand(AspContext context, AddPhotoValidatorDto validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 35;

        public string Name => "AddPhoto";

        public void Execute(AddPhotoDto data)
        {
            _validator.ValidateAndThrow(data);

            
                var tempFile = Path.Combine("wwwroot", "temp", data.ImagePath);
                var destinationFile = Path.Combine("wwwroot", "posts", data.ImagePath);
                System.IO.File.Move(tempFile, destinationFile);
            

            Photo photo = new Photo
            {
              
                PostId = data.PostId,
                Path = data.ImagePath,
                
                
                   
            };

            Context.Photos.Add(photo);

            Context.SaveChanges();
        }
    }
}
