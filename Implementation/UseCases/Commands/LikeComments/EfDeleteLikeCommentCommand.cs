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
    public class EfDeleteLikeCommentCommand : EfUseCase, IDeleteLikeCommentCommand
    {
        private DeleteLikeCommentValidatorDto _validator;
        public EfDeleteLikeCommentCommand(AspContext context, DeleteLikeCommentValidatorDto validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 26;

        public string Name => "DeleteLikeComment";

        public void Execute(BaseDTO data)
        {
            _validator.ValidateAndThrow(data);
            LikeComment likeComments = Context.LikeComments.First(x => x.Id == data.Id);

            Context.LikeComments.Remove(likeComments);

            Context.SaveChanges();
        }
    }
}
