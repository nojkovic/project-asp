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
    public class EfGetPhotoQuery : EfUseCase, IGetPhotoQuery
    {
        public EfGetPhotoQuery(AspContext context) : base(context)
        {
        }

        public int Id => 37;

        public string Name => "GetPhotos";

        public PagedResponse<AddPhotoDto> Execute(SearchPhoto search)
        {
            var query = Context.Photos.AsQueryable();
            if (search.PostId.HasValue)
            {
                query = query.Where(x => x.PostId==search.PostId);
            }
            int totalCount = query.Count();

            int perPage = search.PerPage.HasValue ? (int)Math.Abs((double)search.PerPage) : 5;
            int page = search.Page.HasValue ? (int)Math.Abs((double)search.Page) : 1;


            int skip = perPage * (page - 1);

            query = query.Skip(skip).Take(perPage);

            return new PagedResponse<AddPhotoDto>
            {
                CurrentPage = page,
                Data = query.Select(x => new AddPhotoDto
                {
                    Id = x.Id,
                    PostId = x.PostId,
                    ImagePath=x.Path

                }).ToList(),
                PerPage = perPage,
                TotalCount = totalCount,
                
            };
        }
    }
}
