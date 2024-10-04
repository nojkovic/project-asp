using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;
using Application.UseCases.Queries;
using DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Implementation.UseCases.Queries
{
    public class EfGetLikeCommentQuery : EfUseCase, IGetLikeCommentQuery
    {
        public EfGetLikeCommentQuery(AspContext context) : base(context)
        {
        }

        public int Id => 27;

        public string Name => "SearchLikeComments";

        public PagedResponse<LikeCommentDto> Execute(LikeCommentsSearch search)
        {
            var query = Context.LikeComments.Include(x=>x.User).Include(x=>x.Comment).AsQueryable();
            if (search.UserId.HasValue)
            {
                query = query.Where(x => x.User.Id == search.UserId);
            }
            if (search.CommentId.HasValue)
            {
                query = query.Where(x => x.Comment.Id == search.CommentId);
            }
            
            int totalCount = query.Count();

            int perPage = search.PerPage.HasValue ? (int)Math.Abs((double)search.PerPage) : 5;
            int page = search.Page.HasValue ? (int)Math.Abs((double)search.Page) : 1;


            int skip = perPage * (page - 1);

            query = query.Skip(skip).Take(perPage);
            return new PagedResponse<LikeCommentDto>
            {
                CurrentPage = page,
                Data = query.Select(x => new LikeCommentDto
                {
                    Id = x.Id,
                    UserId = x.User.Id,
                    CommentId = x.Comment.Id,
                    Username=x.User.Username,
                    TextComment=x.Comment.Text,
                    

                }).ToList(),
                PerPage = perPage,
                TotalCount = totalCount

            };
        }
    }
}
