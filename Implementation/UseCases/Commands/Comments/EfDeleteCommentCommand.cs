using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;
using Application.UseCases.Commands.Comments;
using Azure;
using DataAccess;
using Domain;
using FluentValidation;
using Implementation.Validators;

namespace Implementation.UseCases.Commands.Comments
{
    public class EfDeleteCommentCommand : EfUseCase, IDeleteCommentCommand
    {
        private DeleteCommentValidatorDto _validator;
        public EfDeleteCommentCommand(AspContext context, DeleteCommentValidatorDto validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 22;

        public string Name => "DeleteComment";

        public void Execute(BaseDTO data)
        {
            _validator.ValidateAndThrow(data);
            Comment comments = Context.Comments.First(x => x.Id==data.Id);
            
            var likeComComments=comments.LikeComments;
            Context.LikeComments.RemoveRange(likeComComments);

            Context.Comments.Remove(comments);
            Context.SaveChanges();
        }
    }
}
