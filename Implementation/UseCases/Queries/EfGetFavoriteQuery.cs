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
    public class EfGetFavoriteQuery : EfUseCase, IGetFavoriteQuery
    {
        public EfGetFavoriteQuery(AspContext context) : base(context)
        {
        }

        public int Id => 20;

        public string Name => "SearchFavorite";

        public PagedResponse<FavoriteDto> Execute(FavoriteSearch search)
        {
            var query = Context.Favorites.Include(x => x.User).Include(x => x.User).AsQueryable();
            if (search.PostId.HasValue)
            {
                query = query.Where(x => x.PostId == search.PostId);
            }
            if (search.UserId.HasValue)
            {
                query = query.Where(x => x.UserId == search.UserId);
            }
            int totalCount = query.Count();

            int perPage = search.PerPage.HasValue ? (int)Math.Abs((double)search.PerPage) : 5;
            int page = search.Page.HasValue ? (int)Math.Abs((double)search.Page) : 1;


            int skip = perPage * (page - 1);

            query = query.Skip(skip).Take(perPage);

            return new PagedResponse<FavoriteDto>
            {
                CurrentPage = page,
                Data = query.Select(x => new FavoriteDto
                {

                    PostId = x.PostId,
                    UserId = x.UserId,
                    Username=x.User.Username

                }).ToList(),
                PerPage = perPage,
                TotalCount = totalCount,

            };
        }
    }
}
