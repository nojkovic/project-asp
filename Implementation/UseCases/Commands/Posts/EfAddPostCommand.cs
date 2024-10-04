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
    public class EfAddPostCommand : EfUseCase, IAddPostCommand
    {
        private AddPostValidatorDto _validator;
        public EfAddPostCommand(AspContext context, AddPostValidatorDto validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 29;

        public string Name => "AddPost";

        public void Execute(AddPostDto data)
        {
            _validator.ValidateAndThrow(data);
            Post post = new Post
            {
                UserId = data.UserId,
                Text = data.Text
            };

            Context.Posts.Add(post);
            Context.SaveChanges();
        }
    }
}
