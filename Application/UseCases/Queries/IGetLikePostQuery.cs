using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;
using Domain;

namespace Application.UseCases.Queries
{
    public interface IGetLikePostQuery : IQuery<PagedResponse<LikePostDto>, LikePostSearch>
    {
    }
}
