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
    public class EfAddLikeCommentCommand : EfUseCase, IAddLikeCommentCommand
    {
        private AddLikeCommentValidatorDto _validator;
        public EfAddLikeCommentCommand(AspContext context, AddLikeCommentValidatorDto validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 25;

        public string Name => "AddLikeComment";

        public void Execute(AddLikeCommentDto data)
        {
            _validator.ValidateAndThrow(data);
            LikeComment likeComment = new LikeComment
            {
                UserId = data.UserId,
               CommentId = data.CommentId,
            };

            Context.LikeComments.Add(likeComment);
            Context.SaveChanges();
        }
    }
}
