using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;
using Application.UseCases.Commands.Posts;
using Azure;
using DataAccess;
using Domain;
using FluentValidation;
using Implementation.Validators;

namespace Implementation.UseCases.Commands.Posts
{
    public class EfDeletePostCommand : EfUseCase, IDeletePostCommand
    {
        private DeletePostValidatorDto _validator;
        public EfDeletePostCommand(AspContext context, DeletePostValidatorDto validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 30;

        public string Name => "DeletePost";

        public void Execute(BaseDTO data)
        {
            _validator.ValidateAndThrow(data);
            Post post = Context.Posts.First(x => x.Id == data.Id);
            var postComments = post.Comments;
            var postFavorites=post.Favorites;
            var postPhotos= post.Photos;
            var postPostTags=post.PostTags;
            var postLikePosts=post.LikePosts;

            Context.Comments.RemoveRange(postComments);
            Context.Favorites.RemoveRange(postFavorites);
            Context.Photos.RemoveRange(postPhotos);
            Context.PostTags.RemoveRange(postPostTags);
            Context.LikePosts.RemoveRange(postLikePosts);


            Context.Posts.Remove(post);

            Context.SaveChanges();
        }
    }
}
