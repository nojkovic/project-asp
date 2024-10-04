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
    public class EfGetPostTagQuery : EfUseCase, IGetPostTagQuery
    {
        public EfGetPostTagQuery(AspContext context) : base(context)
        {
        }

        public int Id => 19;

        public string Name => "SearchPostTag";

        public PagedResponse<PostTagDto> Execute(PostTagSearch search)
        {
            var query = Context.PostTags.Include(x => x.Tag).Include(x=>x.Tag).AsQueryable();
            if (search.PostId.HasValue)
            {
                query = query.Where(x => x.PostId == search.PostId);
            }
            if (search.TagId.HasValue)
            {
                query = query.Where(x => x.TagId == search.TagId);
            }
            int totalCount = query.Count();

            int perPage = search.PerPage.HasValue ? (int)Math.Abs((double)search.PerPage) : 5;
            int page = search.Page.HasValue ? (int)Math.Abs((double)search.Page) : 1;


            int skip = perPage * (page - 1);

            query = query.Skip(skip).Take(perPage);

            return new PagedResponse<PostTagDto>
            {
                CurrentPage = page,
                Data = query.Select(x => new PostTagDto
                {
                   
                    PostId = x.PostId,
                    TagId = x.TagId,
                    TagName=x.Tag.Name

                }).ToList(),
                PerPage = perPage,
                TotalCount = totalCount,

            };
        }
    }
}
