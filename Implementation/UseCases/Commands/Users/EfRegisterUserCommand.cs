using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;
using Application.UseCases.Commands.Users;
using DataAccess;
using Domain;
using FluentValidation;
using Implementation.Validators;

namespace Implementation.UseCases.Commands.Users
{
    public class EfRegisterUserCommand : EfUseCase, IRegisterUserCommand
    {
        public int Id => 1;

        public string Name => "UserRegistration";

        private RegisterUserDtoValidator _validator;


        public EfRegisterUserCommand(AspContext context,RegisterUserDtoValidator validator) 
            : base(context)
        {
            _validator = validator;
          
        }

        public void Execute(RegisterUserDTO data)
        {
            _validator.ValidateAndThrow(data);
   
            User user = new User
            {
               
                Email = data.Email,
                Name = data.Name,
                LastName = data.LastName,
                Password = BCrypt.Net.BCrypt.HashPassword(data.Password),
                Username = data.Username,
                Photo = data.Photo?? "userdefault.jpg"
   
            };
            if (data.Photo != null)
            {
                var tempFile = Path.Combine("wwwroot", "temp", data.Photo);
                var destinationFile = Path.Combine("wwwroot", "users", data.Photo);
                System.IO.File.Move(tempFile, destinationFile);
            }

            Context.Users.Add(user);

            Context.SaveChanges();
        }
    }
}
