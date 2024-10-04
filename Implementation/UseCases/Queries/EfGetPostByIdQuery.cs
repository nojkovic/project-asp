using System;using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;
using Application.UseCases.Queries;
using DataAccess;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Implementation.UseCases.Queries
{
    public class EfGetPostByIdQuery : EfUseCase, IGetPostByIdQuery
    {
        public EfGetPostByIdQuery(AspContext context) : base(context)
        {
        }

        public int Id => 40;

        public string Name => "SearchPostById";

        public PostByIdDTO Execute(int search)
        {
            var post = Context.Posts.Include(x => x.Photos)
                                    .Include(x => x.PostTags)
                                    .Include(x => x.Favorites)
                                    .Include(x => x.Comments)
                                    .Include(x => x.LikePosts)
                                    .FirstOrDefault(x=>x.Id==search);

             PostByIdDTO dto=new()
            {
                Id= post.Id,
                UserId= post.UserId,
                Text= post.Text,
                CountOfLikes=post.LikePosts.Count(),
                Photos=post.Photos.Select(x=>new AddPhotoDto
                {
                    Id = x.Id,
                    PostId=post.Id,
                    ImagePath=x.Path,
                }).ToList(),
                PostTags=post.PostTags.Select(x=>new PostTagDto
                {
                    TagId=x.TagId,
                    PostId=post.Id
                }).ToList(),
                Favorites=post.Favorites.Select(c=>new FavoriteDto
                {
                    PostId=post.Id,
                    UserId=c.UserId
                }).ToList(),
                 Comments = FillChildrenOfParents(post.Comments?.Where(c => c.ParentId == null).ToList() ?? new List<Comment>()),
                 LikePosts =post.LikePosts.Select(c=> new LikePostDto
                {
                    Id = c.Id,
                    UserId = c.UserId,
                    PostId=post.Id,
                    TypeLikeId=c.TypeLikeId,
                }).ToList()
            };

            

            return dto;

        }
        private List<CommentDto> FillChildrenOfParents(List<Comment> comments)
        {
            var result = new List<CommentDto>();

            foreach (var comment in comments)
            {
                var commentWithChildren = new CommentDto
                {
                    Id = comment.Id,
                    Text = comment.Text,
                    UserId = comment.UserId,
                    ParentId = comment.ParentId,
                    Children = FillChildrenOfParents(comment.Children?.ToList() ?? new List<Comment>())
                };

                result.Add(commentWithChildren);
            }

            return result;
        }
    }
}
