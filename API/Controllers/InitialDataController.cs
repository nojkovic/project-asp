using DataAccess;
using Domain;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InitialDataController : ControllerBase
    {
        AspContext ctx;
        public InitialDataController(AspContext _ctx) 
        {
            ctx = _ctx;
        }
        // GET: api/<InitialDataController>
        [HttpGet]
        public IActionResult Get()
        {
            if (ctx.Users.Any())
            {
                return Conflict("Database is alredy filled.");
            }

            List<int> allowedCasesForUser = new List<int>
            {
              1,3, 4,5,7,8,9, 10, 11,12,15,19, 20,21, 22, 23, 24, 25, 26,27,29, 30, 31,32, 33, 34, 35, 36, 37, 38, 39,40
            };

            List<int> allowedCasesForAdmin = new List<int>
            {
                 1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42
            };

            User u1 = new User
            {
                Name = "User",
                LastName = "User",
                Email = "user@gmail.com",
                Username = "user",
                Password = BCrypt.Net.BCrypt.HashPassword("User123!"),
                UseCases = allowedCasesForUser.Select(u => new UserUseCase
                {
                    UseCaseId = u
                }).ToList()
            };

            User u2 = new User
            {
                Name = "Admin",
                LastName = "Administrator",
                Email = "admin@gmail.com",
                Username = "administrator",
                Password = BCrypt.Net.BCrypt.HashPassword("Administrator123!"),
                UseCases = allowedCasesForUser.Select(u => new UserUseCase
                {
                    UseCaseId = u
                }).ToList()
            };

            Tag t1 = new Tag
            {
                Name = "Natural"
            };

            Tag t2 = new Tag
            {
                Name = "Trending"
            };

            Tag t3 = new Tag
            {
                Name = "Popular"
            };

            TypeLike tl1 = new TypeLike
            {
                Name="Like",
                Photo="like.png"
            };
            TypeLike tl2 = new TypeLike
            {
                Name = "Love",
                Photo = "love.jpg"
            };
            TypeLike tl3 = new TypeLike
            {
                Name = "Hug",
                Photo = "hug.jpeg"
            };

            Post post1 = new Post
            {
                User=u1,
                Text= "Nature, birds, view"

            };

            Post post2 = new Post
            {
                User = u1,
                Text = "Believe in yourself and your dreams. Every step forward is a step closer to success. Keep going, you can do it"

            };
            Photo photo1 = new Photo
            {
                Post=post1,
                Path="natural.jpg",

            };
            Photo photo2 = new Photo
            {
                Post = post1,
                Path = "natural1.jpg",
            };

            Photo photo3 = new Photo
            {
                Post = post2,
                Path="motivation.jpg"
            };
            Favorite fav = new Favorite
            {
                Post = post1,
                User = u1,
            };

            Favorite fav2 = new Favorite
            {
                Post = post2,
                User = u1
            };

            Favorite fav3 = new Favorite
            {
                Post = post2,
                User = u2,
            };

            PostTag postTag1 = new PostTag
            {
                Tag=t1,
                Post=post1
            };

            PostTag postTag2 = new PostTag
            {
                Tag=t2,
                Post=post2
            };

            LikePost likePosts = new LikePost
            {
                User=u1,
                Post=post1,
                TypeLike=tl1,

            };

            LikePost likePosts2 = new LikePost
            {
                User = u1,
                Post = post2,
                TypeLike = tl2,
            };

            LikePost likePosts3 = new LikePost
            {
                User = u2,
                Post = post1,
                TypeLike = tl3,
            };

            Comment comment = new Comment
            {
                User=u1,
                Text="This is so beautiful",
                Post=post1,
            };

            Comment comment1 = new Comment
            {
                User = u2,
                Parent=comment,
                Text = "I completely agree with you",
                Post = post1
            };

            Comment comment2 = new Comment
            {
                User = u1,
                Parent = comment1,
                Text = ":)",
                Post = post1
            };
            Comment comment3 = new Comment
            {
                User = u2,
                Text = "Real motivation",
                Post = post2
            };

            LikeComment likeComment = new LikeComment
            {
                User= u1,
                Comment=comment1,
            };

            LikeComment likeComment1= new LikeComment
            {
                User = u2,
                Comment = comment2,
            };

            LikeComment likeComment2 = new LikeComment
            {
                User = u1,
                Comment = comment3,
            };

            ctx.Users.Add(u1);
            ctx.Users.Add(u2);
            ctx.Tags.Add(t1);
            ctx.Tags.Add(t2);
            ctx.Tags.Add(t3);
            ctx.TypeLikes.Add(tl1);
            ctx.TypeLikes.Add(tl2);
            ctx.TypeLikes.Add(tl3);
            ctx.Posts.Add(post1);
            ctx.Posts.Add(post2);
            ctx.Photos.Add(photo1);
            ctx.Photos.Add(photo2);
            ctx.Photos.Add(photo3);
            ctx.Favorites.Add(fav);
            ctx.Favorites.Add(fav2);
            ctx.Favorites.Add(fav3);
            ctx.PostTags.Add(postTag1);
            ctx.PostTags.Add(postTag2);
            ctx.LikePosts.Add(likePosts);
            ctx.LikePosts.Add(likePosts2);
            ctx.LikePosts.Add(likePosts3);
            ctx.Comments.Add(comment);
            ctx.Comments.Add(comment1);
            ctx.Comments.Add(comment2);
            ctx.Comments.Add(comment3);
            ctx.LikeComments.Add(likeComment);
            ctx.LikeComments.Add(likeComment1);
            ctx.LikeComments.Add(likeComment2);
            ctx.SaveChanges();


            return StatusCode(201);
        }

        
    }
}
