using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;
using Application.UseCases.Commands.LikeComments;
using DataAccess;
using Domain;
using FluentValidation;
using Implementation.Validators;

namespace Implementation.UseCases.Commands.LikeComments
{
    public class EfUpdateLikeCommentCommand : EfUseCase, IUpdateLikeCommentCommand
    {
        private UpdateLikeCommentValidatorDto _validator;
        public EfUpdateLikeCommentCommand(AspContext context, UpdateLikeCommentValidatorDto validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 28;

        public string Name => "UpdateLikeComment";

        public void Execute(UpdateLikeCommentDto data)
        {
             _validator.ValidateAndThrow(data);
            LikeComment likeComment = Context.LikeComments.First(x => x.Id == data.Id);
            likeComment.UserId = data.UserId;
            likeComment.CommentId = data.CommentId;

            Context.SaveChanges();
        }
    }
}
