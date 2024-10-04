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
    public class EfAddLikePostCommand : EfUseCase, IAddLikePostCommand
    {
        private AddLikePostDtoValidator _validator;
        public EfAddLikePostCommand(AspContext context,AddLikePostDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 9;

        public string Name => "AddLikePost";

        public void Execute(AddLikePostDto data)
        {
            _validator.ValidateAndThrow(data);
            LikePost likePost = new LikePost
            {
                UserId = data.UserId,
                PostId = data.PostId,
                TypeLikeId = data.TypeLikeId
            };

            Context.LikePosts.Add(likePost);
            Context.SaveChanges();
        }
    }
}
