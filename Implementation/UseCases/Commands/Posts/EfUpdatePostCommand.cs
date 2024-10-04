using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;
using Application.UseCases.Commands.Posts;
using DataAccess;
using Domain;
using FluentValidation;
using Implementation.Validators;

namespace Implementation.UseCases.Commands.Posts
{
    public class EfUpdatePostCommand : EfUseCase, IUpdatePostCommand
    {
        private UpdatePostValidatorDto _validator;
        public EfUpdatePostCommand(AspContext context, UpdatePostValidatorDto validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 32;

        public string Name => "UpdatePost";

        public void Execute(UpdatePostDto data)
        {
            _validator.ValidateAndThrow(data);
            Post post = Context.Posts.First(x => x.Id == data.Id);
            post.Text = data.Text;
            post.UserId = data.UserId;
            Context.SaveChanges();
        }
    }
}
