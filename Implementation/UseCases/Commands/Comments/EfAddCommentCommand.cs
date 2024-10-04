using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application;
using Application.DTO;
using Application.UseCases.Commands.Comments;
using DataAccess;
using Domain;
using FluentValidation;
using Implementation.Validators;

namespace Implementation.UseCases.Commands.Comments
{
    public class EfAddCommentCommand : EfUseCase, IAddCommentCommand
    {
        private AddCommentValidatorDto _validator;
        private IApplicationActor _actor;
        public EfAddCommentCommand(AspContext context, AddCommentValidatorDto validator, IApplicationActor actor) : base(context)
        {
            _validator = validator;
            _actor = actor;
        }

        public int Id => 21;

        public string Name => "AddComment";

        public void Execute(AddCommentDto data)
        {
            _validator.ValidateAndThrow(data);

            Comment comments = new Comment
            {
                Text = data.Text,
                ParentId = data.ParentId,
                UserId = _actor.Id,
                PostId = data.PostId,

            };

                var childCaomments = Context.Comments
                                         .Where(c => data.ChildIds.Contains(c.Id))
                                          .ToList();
            if (childCaomments.Any())
            {
                comments.Children = childCaomments;
            }
            
            Context.Comments.Add(comments);

            Context.SaveChanges();
        }
    }
}
