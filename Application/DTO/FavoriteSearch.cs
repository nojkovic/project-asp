using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class FavoriteSearch:PagedSearch
    {
        public int? PostId { get; set; }
        public int? UserId { get; set; }
    }
}
