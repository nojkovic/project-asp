﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;
using Application.UseCases.Queries;
using DataAccess;

namespace Implementation.UseCases.Queries
{
    public class EfGetTypeLikeQuery : EfUseCase, IGetTypeLikeQuery
    {
        public EfGetTypeLikeQuery(AspContext context) : base(context)
        {
        }

        public int Id => 7;

        public string Name => "SearchTypeLike";

        public PagedResponse<TypeLikeDto> Execute(TypeLikeSearch search)
        {
            var query = Context.TypeLikes.AsQueryable();
            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.Name.Contains(search.Keyword));
            }
            int totalCount = query.Count();

            int perPage = search.PerPage.HasValue ? (int)Math.Abs((double)search.PerPage) : 5;
            int page = search.Page.HasValue ? (int)Math.Abs((double)search.Page) : 1;


            int skip = perPage * (page - 1);

            query = query.Skip(skip).Take(perPage);
            return new PagedResponse<TypeLikeDto>
            {
                CurrentPage = page,
                Data = query.Select(x => new TypeLikeDto
                {
                    Id = x.Id,
                    Name=x.Name,
                    Photo=x.Photo
                    
                }).ToList(),
                PerPage = perPage,
                TotalCount = totalCount,
            };
        }
    }
}