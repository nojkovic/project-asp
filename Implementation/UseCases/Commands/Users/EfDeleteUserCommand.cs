using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;
using Application.UseCases.Commands.Users;
using DataAccess;
using Domain;
using FluentValidation;
using Implementation.Validators;
using Microsoft.EntityFrameworkCore;

namespace Implementation.UseCases.Commands.Users
{
    public class EfDeleteUserCommand : EfUseCase, IDeleteUsersCommand
    {
        public EfDeleteUserCommand(AspContext context,DeleteUserDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 2;

        public string Name => "UserDelete";

        private DeleteUserDtoValidator _validator;




        public void Execute(BaseUserDto data)
        {
            _validator.ValidateAndThrow(data);
            User user=Context.Users.Include(x=>x.LikePosts)
                                    .Include(x=>x.Comments)
                                    .Include(x=>x.LikeComments)
                                    .Include(x=>x.Posts)
                                    .ThenInclude(x=>x.Favorites)
                                    .First(x=>x.Id==data.Id);

            var userLikeComments = user.LikeComments;
            var userLikePosts = user.LikePosts;
            var userPosts=user.Posts;
            var userFavorites= user.Favorites;
            var userComments= user.Comments;

            var filePath = Path.Combine("wwwroot", "users", user.Photo);
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }


            Context.LikeComments.RemoveRange(userLikeComments);
            Context.LikePosts.RemoveRange(userLikePosts);
            Context.Comments.RemoveRange(userComments);
            Context.Posts.RemoveRange(userPosts);
            Context.Favorites.RemoveRange(userFavorites);

            Context.Users.Remove(user);

            Context.SaveChanges();



        }
    }
}
