using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;
using Application.UseCases.Queries;
using Azure;
using DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Implementation.UseCases.Queries
{
    public class EfGetLikePostQuery : EfUseCase, IGetLikePostQuery
    {
        public EfGetLikePostQuery(AspContext context) : base(context)
        {
        }

        public int Id => 11;

        public string Name => "SearchLikePost";

        public PagedResponse<LikePostDto> Execute(LikePostSearch search)
        {
            var query = Context.LikePosts.Include(x=>x.TypeLike).AsQueryable();
            if (search.UserId.HasValue)
            {
                query = query.Where(x =>x.User.Id==search.UserId);
            }
            if (search.PostId.HasValue)
            {
                query = query.Where(x => x.Post.Id == search.PostId);
            }
            if (search.TypeLikeId.HasValue)
            {
                query = query.Where(x => x.TypeLike.Id == search.TypeLikeId);
            }
            int totalCount = query.Count();

            int perPage = search.PerPage.HasValue ? (int)Math.Abs((double)search.PerPage) : 5;
            int page = search.Page.HasValue ? (int)Math.Abs((double)search.Page) : 1;


            int skip = perPage * (page - 1);

            query = query.Skip(skip).Take(perPage);
            return new PagedResponse<LikePostDto>
            {
               CurrentPage = page,
                Data = query.Select(x => new LikePostDto
                {
                    Id = x.Id,
                    Username = x.User.Username,
                    PostId = x.Post.Id,
                    NameTypeLike=x.TypeLike.Name,
                    
                    
                }).ToList(),
                PerPage = perPage,
                TotalCount = totalCount

            };
        }
    }
}
