using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;
using Application.UseCases.Commands.LikePosts;
using Application.UseCases.Commands.TypeLikes;
using DataAccess;
using FluentValidation;
using Implementation.Validators;

namespace Implementation.UseCases.Commands.LikePosts
{
    public class EfDeleteLikePostCommand : EfUseCase, IDeleteLikePostCommand
    {
        private DeleteLikePostDtoValidator _validator;
        public EfDeleteLikePostCommand(AspContext context,DeleteLikePostDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 10;

        public string Name => "DeleteLikePost";

        public void Execute(BaseDTO data)
        {
            _validator.ValidateAndThrow(data);
            Domain.LikePost likePosts=Context.LikePosts.First(x=>x.Id == data.Id);

            Context.LikePosts.Remove(likePosts);

            Context.SaveChanges();

        }
    }
}
