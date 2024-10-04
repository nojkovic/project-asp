using System;
using System.Collections.Generic;
using System.Linq;
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
    public class EfUpdateUserCommand : EfUseCase, IUpdateUsersCommand
    {

        private UpdateUserDtoValidator _validator;
        public EfUpdateUserCommand(AspContext context,UpdateUserDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 4;

        public string Name => "UserUpdate";

        public void Execute(UpdateUserDto data)
        {
            _validator.ValidateAndThrow(data);
            User user=Context.Users.First(x=>x.Id == data.Id);
            user.Name = data.Name;
            user.Email = data.Email;
            user.LastName= data.LastName;
            user.Username = data.Username;
            user.Password = data.Password;
            user.Photo = data.Photo?? "userdefault.jpg";

            if(data.Photo != null)
            {
                var tempFile = Path.Combine("wwwroot", "temp", data.Photo);
                var destinationFile = Path.Combine("wwwroot", "users", data.Photo);
                System.IO.File.Move(tempFile, destinationFile);
            }

         

            Context.SaveChanges();
        }
    }
}
