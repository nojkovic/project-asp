using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;
using Application.UseCases.Queries;
using DataAccess;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Implementation.UseCases.Queries
{
    public class EfGetCommentQuery : EfUseCase, IGetCommentQuery
    {
        public EfGetCommentQuery(AspContext context) : base(context)
        {
        }

        public int Id => 23;

        public string Name => "SearchComment";

        public PagedResponse<CommentWithoutChildsDTO> Execute(SearchCommentsDTO search)
        {
            var query = Context.Comments.AsQueryable();


            if (search.Id.HasValue)
            {
                query = query.Where(x => x.Id == search.Id);
            }

            if (search.ParentId.HasValue)
            {
                query = query.Where(x => x.ParentId == search.ParentId);
            }

            if (search.PostId.HasValue)
            {
                query = query.Where(x => x.PostId == search.PostId);
            }

            if (search.UserId.HasValue)
            {
                query = query.Where(x => x.UserId == search.UserId);
            }


            int totalCountOfLogs = query.Count();
            int perPage = search.PerPage.HasValue ? (int)Math.Abs((double)search.PerPage) : 5;
            int page = search.Page.HasValue ? (int)Math.Abs((double)search.Page) : 1;
            int skip = perPage * (page - 1);

            query = query.Skip(skip).Take(perPage);

            return new PagedResponse<CommentWithoutChildsDTO>
            {
                CurrentPage = page,
                Data = query.Select(x => new CommentWithoutChildsDTO
                {
                    Id = x.Id,
                    ParentId = x.ParentId,
                    Text = x.Text,
                    UserId = x.UserId,
                    PostId = x.PostId
                }).ToList(),

                PerPage = perPage,
                TotalCount = totalCountOfLogs,
            };
        }
    }
}
