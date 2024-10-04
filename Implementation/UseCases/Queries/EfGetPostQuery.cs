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
    public class EfGetPostQuery : EfUseCase, IGetPostQuery
    {
        public EfGetPostQuery(AspContext context) : base(context)
        {
        }

        public int Id => 31;

        public string Name => "SearchPost";

        public PagedResponse<PostDTO> Execute(SearchPostDto search)
        {
            var query = Context.Posts.Include(x => x.LikePosts).AsQueryable();


            if (search.Id.HasValue)
            {
                query = query.Where(x => x.Id == search.Id);
            }

            if (!string.IsNullOrEmpty(search.Text))
            {
                query = query.Where(x => x.Text.ToLower().Contains(search.Text.ToLower()));
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

            return new PagedResponse<PostDTO>
            {
                CurrentPage = page,
                Data = query.Select(x => new PostDTO
                {
                    Id = x.Id,
                    Text = x.Text,
                    UserId = x.UserId,
                    Username=x.User.Username,
                    LikeCount=x.LikePosts.Count()
                   

                }).ToList(),

                PerPage = perPage,
                TotalCount = totalCount,
            };
        }
    }
}

