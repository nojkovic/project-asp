using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;
using Application.UseCases.Queries;
using DataAccess;

namespace Implementation.UseCases.Queries
{
    public class EfGetUsersQuery : EfUseCase, IGetUsersQuery
    {
        public EfGetUsersQuery(AspContext context) : base(context)
        {
        }
        public int Id => 3;

        public string Name => "Search Users";

        public PagedResponse<UserDTO> Execute(UserSearch search)
        {
            var query = Context.Users.AsQueryable();

            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.Username.Contains(search.Keyword) ||
                                         x.Email.Contains(search.Keyword));
            }

            if (search.MinPosts.HasValue && search.MinPosts.Value >= 0)
            {
                query = query.Where(x => x.Posts.Count() > search.MinPosts.Value);
            }

            int totalCount = query.Count();

            int perPage = search.PerPage.HasValue ? (int)Math.Abs((double)search.PerPage) : 5;
            int page = search.Page.HasValue ? (int)Math.Abs((double)search.Page) : 1;


            int skip = perPage * (page - 1);

            query = query.Skip(skip).Take(perPage);

            return new PagedResponse<UserDTO>
            {
                CurrentPage = page,
                Data = query.Select(x => new UserDTO
                {
                    Id = x.Id,
                    Email = x.Email,
                    Name = x.Name,
                    Photo = x.Photo,
                    LastName = x.LastName,
                    Username = x.Username,
                    PostsCount = x.Posts.Count()
                }).ToList(),
                PerPage = perPage,
                TotalCount = totalCount,
            };
        }
    }
}
