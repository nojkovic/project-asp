using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;
using Application.UseCases.Commands.LikePosts;
using Application.UseCases.Commands.TypeLikes;
using DataAccess;
using Domain;
using FluentValidation;
using Implementation.Validators;

namespace Implementation.UseCases.Commands.LikePosts
{
    public class EfUpdateLikePostCommand : EfUseCase, IUpdateLikePostCommand
    {
        private UpdateLikePostDtoValidator _validator;
        public EfUpdateLikePostCommand(AspContext context,UpdateLikePostDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 12;

        public string Name => "UpdateLikePost";

        public void Execute(UpdateLikePostDto data)
        {
            _validator.ValidateAndThrow(data);
            LikePost likePosts = Context.LikePosts.First(x => x.Id == data.Id);
            likePosts.UserId = data.UserId;
            likePosts.PostId = data.PostId;
            likePosts.TypeLikeId = data.TypeLikeId;
            Context.SaveChanges();
        }
    }
}
