using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class PostTagSearch:PagedSearch
    {
        public int? TagId { get; set; }
        public int? PostId { get; set; }
    }
}

