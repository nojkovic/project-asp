using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Application;
using Application.DTO;
using Application.UseCases.Commands.Comments;
using DataAccess;
using Domain;
using FluentValidation;
using Implementation.Validators;
using Microsoft.EntityFrameworkCore;

namespace Implementation.UseCases.Commands.Comments
{
    public class EfUpdateCommentCommand : EfUseCase, IUpdateCommentComand
    {
        private UpdateCommentValidatorDto _validator;
        private IApplicationActor _actor;
        public EfUpdateCommentCommand(AspContext context, UpdateCommentValidatorDto validator, IApplicationActor actor) : base(context)
        {
            _validator = validator;
            _actor = actor;
        }

        public int Id => 24;

        public string Name => "UpdateComment";

        public void Execute(UpdateCommentDto data)
        {
            _validator.ValidateAndThrow(data);
            Comment comments = Context.Comments.Include(c=>c.Children).FirstOrDefault(x => x.Id == data.Id);
            comments.Text = data.Text;
            comments.UserId = _actor.Id;
            comments.PostId = data.PostId;

            foreach (var child in comments.Children)
            {
                child.ParentId = null;
            }

            if (data.ChildIds != null && data.ChildIds.Any())
            {
                List<Comment> comment = Context.Comments.Where(x => data.ChildIds.Contains(x.Id)).ToList();
                comments.Children = comment;
            }

            Context.SaveChanges();

        }
    }
}
